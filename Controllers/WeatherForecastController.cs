using Microsoft.AspNetCore.Mvc;
using StudentTracker1.Context;

namespace StudentTracker1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly static List<StudentReport> list = new List<StudentReport>()
            {
                new StudentReport() { Name = "Beth", Course = "English", Grade = 98 },
                new StudentReport() { Name = "Allen", Course = "Science", Grade = 83 },
                new StudentReport() { Name = "Greg", Course = "Math", Grade = 80 },
                new StudentReport() { Name = "Bob", Course = "Art", Grade = 92 },
                new StudentReport() { Name = "Jane", Course = "History", Grade = 90 },
                new StudentReport() { Name = "John", Course = "Quantum Physics", Grade = 88 },
            };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.Log(LogLevel.Information, "Getting weather data");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("students")]
        public IEnumerable<StudentReport> GetStudentReports()
        {
            return list;
        }
    }
}