using dotenv.net;
using GoldGymAPI;
using Microsoft.EntityFrameworkCore;
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!.Replace("{Password}", Environment.GetEnvironmentVariable("DatabasePassword"));

builder.Services.AddDbContext<GoldGymContext>(options =>
    options.UseNpgsql(connectionString));

System.Console.WriteLine(connectionString);


var app = builder.Build();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();