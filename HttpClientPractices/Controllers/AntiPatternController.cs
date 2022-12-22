using HttpClientPractices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HttpClientPractices.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AntiPatternController : ControllerBase
{
    [HttpPost("Test")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri(Constants.PathToWeatherApi)
        };

        var opeartionResult = await client.GetAsync(Constants.GetWeatherEndpoint);

        if (opeartionResult.IsSuccessStatusCode)
        {
            var jsonString = await opeartionResult.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);

            return Ok(model);
        }

        return BadRequest();
    }
}