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

var app = builder.Build();
app.UseRouting();

app.UseAuthentication(); // If using authentication
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.Run();