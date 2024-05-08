namespace AspireAppPlayground.ApiService;

public static class WeatherForecastEndpoints
{
    private static readonly string[] Summaries =
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

    public static WebApplication MapWeatherForecastEndpoints(this WebApplication app)
    {
        app.MapGet($"/{Constants.WeatherForecastEndpoint}", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        Summaries[Random.Shared.Next(Summaries.Length)]
                    ))
                .ToArray();
            return forecast;
        });

        return app;
    }
}
