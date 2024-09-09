using Microsoft.AspNetCore.Mvc;
using NetConf.ConfClasses;
using NetConf.Services;

namespace NetConf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IConfiguration _configuration;

        private readonly TennacyService _tennacyService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, TennacyService tennacyService)
        {
            _tennacyService = tennacyService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var deneme = _configuration["Deneme"];
            //var deneme2 = new TennacyService(_configuration.Get<DbSettings>()).GetConnectionString();

            var deneme2 = _tennacyService.GetConnectionString();



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
