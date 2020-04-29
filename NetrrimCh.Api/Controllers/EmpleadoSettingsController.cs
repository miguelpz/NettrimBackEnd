using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Empleado;
using NettrimCh.Api.Application.Contracts.ServiceContracts.EmpleadoSettings;
using NettrimCh.Api.Application.Services;

namespace NettrimCh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoSettingsController : ControllerBase
    {
        private readonly IEmpleadoSettingsApplicationService _empleadoSettingsApplicationService;
        public EmpleadoSettingsController(IEmpleadoSettingsApplicationService empleadoSettingsApplicationService)
        {
            _empleadoSettingsApplicationService = empleadoSettingsApplicationService;
        }

        // POST: api/EmpleadoSettings
        [HttpPost]
        public IActionResult Post( EmpleadoSettingsDto empleadoSettings)
        {
            try
            {
                var empleadoSettingsAdded = _empleadoSettingsApplicationService.Add(empleadoSettings);
                return Ok(empleadoSettingsAdded);
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
