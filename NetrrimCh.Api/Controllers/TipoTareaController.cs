using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.TipoTarea;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTareaController : ControllerBase
    {
        private readonly ITipoTareaApplicationService _tipoTareaApplicationSerice;
        public TipoTareaController(ITipoTareaApplicationService tipoTareaApplicationSerice)
        {
            _tipoTareaApplicationSerice = tipoTareaApplicationSerice;
        }

        // GET: api/Clientes
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var clientList = _tipoTareaApplicationSerice.GetAll();
                return Ok(clientList);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var client = _tipoTareaApplicationSerice.GetById(id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Post([FromBody] TipoTareaDto tipoTarea)
        {
            try
            {
                var tipoTareaAdded = _tipoTareaApplicationSerice.Add(tipoTarea);
                return Ok(tipoTareaAdded);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoTareaDto ctipoTarea)
        {
            try
            {
                _tipoTareaApplicationSerice.Update(id, ctipoTarea);
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
                var tipoTareaToDelete = _tipoTareaApplicationSerice.Delete(id);
                return Ok(tipoTareaToDelete);
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