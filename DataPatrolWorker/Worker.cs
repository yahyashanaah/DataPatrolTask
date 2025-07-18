using DataPatrolTask.DataMigration;
using DataPatrolTask.Models;
using Microsoft.EntityFrameworkCore;

public class Worker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<Worker> _logger;

    public Worker(IServiceScopeFactory scopeFactory, ILogger<Worker> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            try
            {
                var request = await db.UserRequests
                    .Include(r => r.RequestedUser)
                    .Where(r =>
                        r.RequestDateTime < DateTime.UtcNow &&
                        r.Status == RequestStatus.Draft)
                    .OrderBy(r => r.RequestDateTime)
                    .FirstOrDefaultAsync(stoppingToken);

                if (request != null)
                {
                    request.Status = RequestStatus.InReview;
                    await db.SaveChangesAsync();

                    await Task.Delay(10000, stoppingToken); // Wait 10 seconds before processing

                    if (request.RequestedUser == null || !request.RequestedUser.IsEnabled)
                    {
                        request.Status = RequestStatus.Rejected;
                    }
                    else if (request.RequestCode % 4 == 0)
                    {
                        request.Status = RequestStatus.Rejected;
                    }
                    else
                    {
                        request.Status = RequestStatus.Approved;
                    }

                    request.CompletionDateTime = DateTime.UtcNow;
                    await db.SaveChangesAsync();
                }
                else
                {
                    await Task.Delay(10000, stoppingToken); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");
            }
        }
    }
}
