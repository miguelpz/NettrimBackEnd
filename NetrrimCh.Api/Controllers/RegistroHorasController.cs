﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Contracts.ServiceContracts.ProyectoEmpleado;
using NettrimCh.Api.Application.Services;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroHorasController : ControllerBase
    {
        private readonly IRegistroHorasApplicationService _registroHorasApplicationSerice;
        public RegistroHorasController(IRegistroHorasApplicationService registroHorasApplicationService)
        {
            _registroHorasApplicationSerice = registroHorasApplicationService;
        }
        
        // GET: api/Clientes
        [HttpGet("{tareaId}/{month}/{year}")]        
        public IActionResult Get(int tareaId, int month, int year)        
        {
            try
            {
                var monthInputList = _registroHorasApplicationSerice.GetMonthInputs(tareaId, month, year);
               return Ok(monthInputList);
            } 
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }                              
        }

        [HttpPut()]
        public IActionResult Put(IEnumerable<RegistroHorasDto> monthHours)
        {
            try
            {
                _registroHorasApplicationSerice.UpdateMonthInputs(monthHours.Select(o => o.Id).ToList(), monthHours);
                return Ok();
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
