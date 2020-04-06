using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NettrimCh.Api.Domain.ServicesContracts.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NettrimCh.Api.Domain.ServicesImplementatios.Comon
{
    public class OperationFileResponse
    {
        public bool Ok { get; set; }
        public string Result { get; set; }
    }

    public class AttachFileService : IAttachFileService
    {
        private const string UPLOADS_DIRECTORY = @"\Uploads";

        private IHostingEnvironment _env;

        public AttachFileService(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<OperationFileResponse> AddFile(string tipoTarea, string idNameEmpleado, IFormFile file)
        {
            var webRoot = _env.ContentRootPath + UPLOADS_DIRECTORY;
            var path = System.IO.Path.Combine(webRoot, tipoTarea, idNameEmpleado);


            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            var filePathComeplete = System.IO.Path.Combine(path, file.FileName);

            try
            {
                using (var stream = new FileStream(filePathComeplete, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            catch (Exception ex)
            {

                return new OperationFileResponse() { Ok = false, Result = ex.Message };
            }

            return new OperationFileResponse() { Ok = true, Result = filePathComeplete };
        }

        public OperationFileResponse DeleteFile(string filePath)
        {
            var webRoot = _env.ContentRootPath + @"\Uploads";

            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {

                return new OperationFileResponse() { Ok = false, Result = ex.Message };
            }

            return new OperationFileResponse() { Ok = true, Result = filePath };
        }



    }
}
