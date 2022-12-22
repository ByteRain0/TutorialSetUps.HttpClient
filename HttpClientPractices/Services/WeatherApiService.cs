using HttpClientPractices.Models;
using System.Text.Json;

namespace HttpClientPractices.Services;

public class WeatherApiService : IWeatherApiService
{
    public static readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri(Constants.PathToWeatherApi)
    };

    public async Task<List<WeatherForecast>> GetWeather()
    {

        var opeartionResult = await _httpClient.GetAsync(Constants.GetWeatherEndpoint);

        if (opeartionResult.IsSuccessStatusCode)
        {
            var jsonString = await opeartionResult.Content.ReadAsStringAsync();

            var list = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);

            if (list != null) return list;
        }

        return new List<WeatherForecast>();
    }
}