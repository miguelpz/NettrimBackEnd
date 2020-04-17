using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Empleado;
using NettrimCh.Api.Application.Services;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoApplicationService _empleadoApplicationService;
        public EmpleadosController(IEmpleadoApplicationService empleadoApplicationService)
        {
            _empleadoApplicationService = empleadoApplicationService;
        }
        
        // GET: api/Empleados
        [HttpGet]
        public IActionResult GetAll()

        {
            try
            {
                var clientList = _empleadoApplicationService.GetAll();
                return Ok(clientList);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var empleado = _empleadoApplicationService.GetById(id);
                return Ok(empleado);
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
        public IActionResult Post([FromBody] EmpleadoDto empleado)
        {
            try
            {
                var clienteAdded = _empleadoApplicationService.Add(empleado);
                return Ok(clienteAdded);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Empleados/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmpleadoDto empleado)
        {
            try
            {
                _empleadoApplicationService.Update(id, empleado);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deletedObject = _empleadoApplicationService.Delete(id);
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
