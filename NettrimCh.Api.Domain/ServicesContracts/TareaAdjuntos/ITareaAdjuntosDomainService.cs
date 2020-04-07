using Microsoft.AspNetCore.Http;
using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NettrimCh.Api.Domain.ServicesContracts.TareaAdjuntos
{
    public interface ITareaAdjuntosDomainService
    {
        Task AddAttachment(int idTarea, IFormFile file);
        void DeleteAttachment(int idAttachment);
    }
}

