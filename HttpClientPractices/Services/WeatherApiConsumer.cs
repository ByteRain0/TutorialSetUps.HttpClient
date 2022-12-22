using HttpClientPractices.Models;
using System.Text.Json;

namespace HttpClientPractices.Services;

public class WeatherApiConsumer : IWeatherApiService
{
    private readonly HttpClient _client;

    public WeatherApiConsumer(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<WeatherForecast>> GetWeather()
    {
        var opeartionResult = await _client.GetAsync(Constants.GetWeatherEndpoint);

        if (opeartionResult.IsSuccessStatusCode)
        {
            var jsonString = await opeartionResult.Content.ReadAsStringAsync();

            var list = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);

            if (list != null) return list;
        }

        return new List<WeatherForecast>();
    }
}