using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.Memory;

namespace HybridCacheSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(HybridCache hybridCache, ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var response = await hybridCache.GetOrCreateAsync("weatherForecast",
                                                                    x => ValueTask.FromResult(GetWeatherForecastCollection()),
                                                                    new HybridCacheEntryOptions
                                                                    {
                                                                        Expiration = TimeSpan.FromMinutes(5)
                                                                    });
           

            return response;
        }

        private static IList<WeatherForecast> GetWeatherForecastCollection()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
