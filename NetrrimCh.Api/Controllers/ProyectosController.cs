using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Proyecto;
using NettrimCh.Api.Application.Services;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectoApplicationService _proyectoApplicationService;
        public ProyectosController(IProyectoApplicationService proyectoApplicationSerice)
        {
            _proyectoApplicationService = proyectoApplicationSerice;
        }

        // GET: api/Clientes
        [HttpGet]
        public IActionResult GetAll()

        {
            try
            {
                var proyectList = _proyectoApplicationService.GetAll();
                return Ok(proyectList);
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
                var proyect = _proyectoApplicationService.GetById(id);
                return Ok(proyect);
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
                var proyectoAdded = _proyectoApplicationService.Add(cliente);
                return Ok(proyectoAdded);
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
        public IActionResult Put(int id, [FromBody] ClienteDto cliente)
        {
            try
            {
                _proyectoApplicationService.Update(id, cliente);
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
                var deletedObject = _proyectoApplicationService.Delete(id);
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
