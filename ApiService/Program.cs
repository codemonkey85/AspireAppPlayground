var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app
    .MapWeatherForecastEndpoints()
    .MapDefaultEndpoints()
    .Run();
