using DataPatrolTask.Services.Interfaces;
using DataPatrolTask.Services.Repositories;
using DataPatrolTask.Models;
using Microsoft.EntityFrameworkCore;
using DataPatrolTask.DataMigration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
//builder.Services.AddScoped<IPolicyTableRepository, PolicyTableRepository>();
builder.Services.AddScoped<IUserRequestRepository, UserRequestRepository>();
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();


var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
