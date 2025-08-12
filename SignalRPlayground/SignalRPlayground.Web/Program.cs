using SignalRPlayground.Data.Models.Contexts;
using SignalRPlayground.Repositories.Users;
using SignalRPlayground.UserTools.UserManager;
using SignalRPlayground.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddDbContext<LocalPlaygroundContext>();

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