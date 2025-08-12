using System.Configuration;
using Microsoft.EntityFrameworkCore;
using SignalRPlayground.Data.Models.Contexts;
using SignalRPlayground.Repositories.Users;
using SignalRPlayground.UserTools.UserManager;
using SignalRPlayground.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("LocalPlayground");

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddDbContext<LocalPlaygroundContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INewUserManager, NewUserManager>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/hub");
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();