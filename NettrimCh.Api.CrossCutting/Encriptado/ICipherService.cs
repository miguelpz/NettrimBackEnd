using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.CrossCutting.Encriptado
{
    public interface ICipherService
    {
        string Encrypt(string input);
        string Decrypt(string cipherText);
    }
}
