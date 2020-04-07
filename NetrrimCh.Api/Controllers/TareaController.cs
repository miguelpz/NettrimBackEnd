using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Tarea;

using NettrimCh.Api.Application.Services;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaApplicationService _tareaApplicationSerice;
        public TareaController(ITareaApplicationService clienteApplicationSerice)
        {
            _tareaApplicationSerice = clienteApplicationSerice;
        }
        
        // GET: api/Tareas
        [HttpGet]        
        public IActionResult GetAll()
        
        {
            try
            {
               var clientList = _tareaApplicationSerice.GetAll();
               return Ok(clientList);
            } 
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }                              
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]        
        public IActionResult Get(int id)
        {
            try
            {
                var client = _tareaApplicationSerice.GetById(id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Tareas
        [HttpPost]
        public IActionResult Post([FromBody] TareaDto tarea)
        {
            try
            {
                var clienteAdded = _tareaApplicationSerice.Add(tarea);
                return Ok(clienteAdded);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Tareas/5
        [HttpPut("{id}")]
        public IActionResult Put( int id, [FromBody] TareaDto tarea)
        {
            try
            {
                _tareaApplicationSerice.Update(id, tarea);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {                
                var deletedObject=_tareaApplicationSerice.Delete(id);
                return Ok(deletedObject);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
