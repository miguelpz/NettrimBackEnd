﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
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
        
        // GET: api/Proyectos
        [HttpGet]        
        public IActionResult GetAll()
        
        {
            try
            {
               var proyectoList = _proyectoApplicationService.GetAll();
               return Ok(proyectoList);
            } 
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }                              
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]        
        public IActionResult Get(int id)
        {
            try
            {
                var proyecto = _proyectoApplicationService.GetById(id);
                return Ok(proyecto);
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
        public IActionResult Post([FromBody] ProyectoDto proyecto)
        {
            try
            {
                var proyectoAdded = _proyectoApplicationService.Add(proyecto);
                return Ok(proyectoAdded);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        public IActionResult Put( int id, [FromBody] ProyectoDto proyecto)
        {
            try
            {
                _proyectoApplicationService.Update(id, proyecto);
                return Ok(proyecto);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {                
                var deletedObject= _proyectoApplicationService.Delete(id);
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
