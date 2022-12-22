namespace HttpClientPractices.Services;

public interface IWeatherApiService
{
    Task<List<WeatherForecast>> GetWeather();
}