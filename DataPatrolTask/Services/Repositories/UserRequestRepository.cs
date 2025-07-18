using DataPatrolTask.DataMigration;
using DataPatrolTask.Models;
using DataPatrolTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataPatrolTask.Services.Repositories
{
    public class UserRequestRepository : IUserRequestRepository
    {
        private readonly AppDbContext context;
        public UserRequestRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<UserRequest>> GetAllAsync()
        {
            return await context.UserRequests.ToListAsync();
        }

        public async Task<UserRequest?> GetByIdAsync(long requestId)
        {
            return await context.UserRequests.FirstOrDefaultAsync(x => x.RequestId == requestId);
        }

        public async Task<UserRequest> CreateAsync(UserRequest request)
        {
            if (request.Status == 0)
            {
                request.Status = RequestStatus.Draft;
            }
                

            context.UserRequests.Add(request);
            await context.SaveChangesAsync();
            return request;
        }


        public async Task<UserRequest?> UpdateAsync(long requestId, UserRequest request)
        {
            var result = await context.UserRequests.FindAsync(requestId);
            if (result == null) return null;

            result.RequestedBy = request.RequestedBy;
            result.RequestedUserUserId = request.RequestedUserUserId;
            result.Description = request.Description;
            result.RequestCode = request.RequestCode;
            result.Status = request.Status;
            result.CompletionDateTime = request.CompletionDateTime;

            await context.SaveChangesAsync();
            return result;
        }
        public async Task<UserRequest?> DeleteAsync(long requestId)
        {
            var result = await context.UserRequests.FindAsync(requestId);
            if(result == null)
            {
                return null;
            }

            context.UserRequests.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }
        public async Task<IEnumerable<UserRequest>> GetRequestsByUserIdAsync(string userId)
        {
            try
            {
                var result = await context.UserRequests
                .Where(x => x.RequestedUser.UserId == userId)
                .OrderByDescending(x => x.RequestDateTime)
                .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

    }
}
