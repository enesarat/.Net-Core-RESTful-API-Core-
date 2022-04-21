using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IRsaHelperService
    {
        string Encrypt(string plainText);
        string Decrypt(string encryptedText);
    }
}
