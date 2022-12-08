using Ezx.Core.Hub;
using Ezx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultipleListerner.ExistingProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabitMqTestingAPI.Controllers
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
        private readonly IEzMessageHub _ezMessageHub;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEzMessageHub ezMessageHub)
        {
            _logger = logger;
            _ezMessageHub = ezMessageHub;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<EzMessageHub>> CreateEmployee(EzxTripView employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
               await _ezMessageHub.OnTripCreated(employee);

                return null;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
    }
}
