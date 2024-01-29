using dotenv.net;
using GoldGymAPI;
using Microsoft.EntityFrameworkCore;
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GoldGymContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") + $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};"));

var app = builder.Build();

// Configure the HTTP request pipeline and the rest of your app...

app.Run();

app.Run();
