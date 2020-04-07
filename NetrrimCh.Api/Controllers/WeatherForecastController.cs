using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NettrimCh.Api.Domain.ServicesContracts.TareaAdjuntos;

namespace NetrrimCh.Api.Controllers
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
        private readonly ITareaAdjuntosDomainService _tareaAdjuntosDomainService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITareaAdjuntosDomainService tareaAdjuntosDomainService)
        {
            _logger = logger;
            _tareaAdjuntosDomainService = tareaAdjuntosDomainService;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
               _tareaAdjuntosDomainService.DeleteAttachment(id);
                return Ok();
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public async Task Post([FromForm] int idTarea, [FromForm] IFormFile file)
        {
            await _tareaAdjuntosDomainService.AddAttachment(idTarea, file);
            

        }
    }
}
