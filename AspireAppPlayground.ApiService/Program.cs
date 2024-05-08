var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

string[] summaries =
[
  "Freezing",
  "Bracing",
  "Chilly",
  "Cool",
  "Mild",
  "Warm",
  "Balmy",
  "Hot",
  "Sweltering",
  "Scorching"
];

app.MapGet("/weatherforecast", () =>
{
  var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        Random.Shared.Next(-20, 55),
        summaries[Random.Shared.Next(summaries.Length)]
      ))
    .ToArray();
  return forecast;
});

app.MapDefaultEndpoints();

app.Run();

#pragma warning disable IDE0079
[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
#pragma warning restore IDE0079
internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  // ReSharper disable once UnusedMember.Global
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
