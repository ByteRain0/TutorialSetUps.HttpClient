using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using HttpClientPractices.Models;

namespace HttpClientPractices.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AntiPatternVariationController : ControllerBase
{
    [HttpPost("Test")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        using (var client = new HttpClient() { BaseAddress = new Uri(Constants.PathToWeatherApi) })
        {
            var opeartionResult = await client.GetAsync(Constants.PathToWeatherApi);

            if (opeartionResult.IsSuccessStatusCode)
            {
                var jsonString = await opeartionResult.Content.ReadAsStringAsync();

                var model = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);

                return Ok(model);
            }
        }

        return BadRequest();
    }
}
