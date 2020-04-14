using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Services;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationSerice;
        public ClientesController(IClienteApplicationService clienteApplicationSerice)
        {
            _clienteApplicationSerice = clienteApplicationSerice;
        }
        
        // GET: api/Clientes
        [HttpGet]        
        public IActionResult GetAll()
        
        {
            try
            {
               var clientList = _clienteApplicationSerice.GetAll();
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
                var client = _clienteApplicationSerice.GetById(id);
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
        public IActionResult Post([FromBody] ClienteDto cliente)
        {
            try
            {
                var clienteAdded = _clienteApplicationSerice.Add(cliente);
                return Ok(clienteAdded);
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
        public IActionResult Put( int id, [FromBody] ClienteDto cliente)
        {
            try
            {
                _clienteApplicationSerice.Update(id, cliente);
                return Ok(cliente);
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
                var deletedObject=_clienteApplicationSerice.Delete(id);
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
