﻿using Microsoft.AspNetCore.Http;
using NettrimCh.Api.Domain.ServicesImplementatios.Comon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NettrimCh.Api.Domain.ServicesContracts.Common
{
    public interface IAttachFileService
    {
        Task<OperationFileResponse> AddFile(string idTarea, string nombreEmpleado, IFormFile file);
        OperationFileResponse DeleteFile(string filePath);
    }
}
