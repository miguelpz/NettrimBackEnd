using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;
        public ClientesController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }
        
        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<ClienteDto> GetAll()
        {
            return _clienteApplicationService.GetAll();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clientes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
