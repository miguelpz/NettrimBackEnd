using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        public string UplodasDirectory { get; set; }

        private IHostingEnvironment _env;
        private IConfiguration _configuration;

        public AttachFileService(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
            UplodasDirectory = _configuration.GetValue<string>("GeneralParameters:UploadDirectory");
            
        }

        public async Task<OperationFileResponse> AddFile(string filePath, IFormFile file)
        {
            var webRoot = _env.ContentRootPath + UplodasDirectory;
            var absolutePath = System.IO.Path.Combine(webRoot, filePath);


            if (!Directory.Exists(absolutePath))
            {
                DirectoryInfo di = Directory.CreateDirectory(absolutePath);
            }

            var filePathComeplete = System.IO.Path.Combine(absolutePath, file.FileName);
            var relativePathComplete = System.IO.Path.Combine(filePath, file.FileName);

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

            return new OperationFileResponse() { Ok = true, Result = relativePathComplete };
        }

        public void DeleteFile(string filePath)
        {

            var webRoot = _env.ContentRootPath + UplodasDirectory;
            var absoluteFilePath = System.IO.Path.Combine(webRoot, filePath);
          
                File.Delete(absoluteFilePath);          
        }



    }
}
