using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NettrimCh.Api.CrossCutting.Encriptado;
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
        private readonly ICipherService _cipherService;
        

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITareaAdjuntosDomainService tareaAdjuntosDomainService, ICipherService cipherService)
        {
            _logger = logger;
            _tareaAdjuntosDomainService = tareaAdjuntosDomainService;
            _cipherService = cipherService;


        }
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _cipherService.Encrypt("holita");
            var result2 = _cipherService.Encrypt("pastakaslpi_3").Length;
            var result3 = _cipherService.Encrypt("holita");

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
