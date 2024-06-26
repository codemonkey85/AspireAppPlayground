namespace AspireAppPlayground.Web;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast>? forecasts = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>($"/{Constants.WeatherForecastEndpoint}", cancellationToken))
        {
            if (forecasts?.Count >= maxItems)
            {
                break;
            }

            if (forecast is null)
            {
                continue;
            }

            forecasts ??= [];
            forecasts.Add(forecast);
        }

        return forecasts?.ToArray() ?? [];
    }
}
