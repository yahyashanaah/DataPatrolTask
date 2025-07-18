using DataPatrolTask.DataMigration;
using DataPatrolTask.Services.Interfaces;
using DataPatrolTask.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRequestRepository, UserRequestRepository>();

var host = builder.Build();
host.Run();
