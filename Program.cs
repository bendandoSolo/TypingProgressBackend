using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITestProj1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Still log to the console (optional)
builder.Logging.AddDebug();    // This will log to the Output window

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



string DefaultConnection = "Server=(localdb)\\MSSQLLocalDB;Database=TypingProgress;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<TypingDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(DefaultConnection)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Testing logging in Program.cs");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{

    logger.LogInformation("weatherforecast endpoint requested");
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/typingData", async ([FromServices]  TypingDBContext dbContext) =>
{
    logger.LogInformation("typing data endpoint requested");
    var items = await dbContext.Typing2024s.ToListAsync();
    return Results.Ok(items);
})
.WithName("typingData")
.WithOpenApi();

logger.LogInformation("Testing logging in Program.cs");
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
