using Microsoft.AspNetCore.DataProtection;

using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace NettrimCh.Api.CrossCutting.Encriptado
{
    public class CipherService: ICipherService
    {
        public IConfiguration Configuration { get; }
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private  string Key { get; set; }       
        public CipherService(IDataProtectionProvider dataProtectionProvider,                             
                             IConfiguration configuration)
        {
            Configuration = configuration;
            _dataProtectionProvider = dataProtectionProvider;
            Key = Configuration.GetValue <string>("InternalCodes:CryptSeed");
        }
        public string Encrypt(string input)
        {          
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }
        public string Decrypt(string cipherText)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(cipherText);
        }
    }
}
