namespace AspireAppPlayground.Web.Components.Pages;

// ReSharper disable once UnusedType.Global
public partial class Weather
{
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync() =>
        forecasts = await WeatherApi.GetWeatherAsync();
}
