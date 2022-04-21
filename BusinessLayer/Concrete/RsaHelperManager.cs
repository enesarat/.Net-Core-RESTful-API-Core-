using BusinessLayer.Abstract;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class RsaHelperManager : IRsaHelperService
    {
        private readonly RSACryptoServiceProvider _privateKey;
        private readonly RSACryptoServiceProvider _publicKey;

        public RsaHelperManager()
        {
            string public_pem = @"..\keys\mypublickey.pem";
            string private_pem = @"..\keys\myprivatekey.pem";

            _privateKey = GetPrivateKeyFromPemFile(private_pem);
            _publicKey = GetPublicKeyFromPemFile(public_pem);
        }

        public string Decrypt(string encryptedText)
        {
            var decryptedBytes = _privateKey.Decrypt(Convert.FromBase64String(encryptedText), false);
            return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
        }

        public string Encrypt(string plainText)
        {
            var encryptedBytes = _publicKey.Encrypt(Encoding.UTF8.GetBytes(plainText), false);
            return Convert.ToBase64String(encryptedBytes);
        }

        private RSACryptoServiceProvider GetPrivateKeyFromPemFile(string filePath)
        {
            using (TextReader privateKeyTextReader = new StringReader(File.ReadAllText(filePath)))
            {
                AsymmetricCipherKeyPair readKeyPair = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)readKeyPair.Private);
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }

        private RSACryptoServiceProvider GetPublicKeyFromPemFile(String filePath)
        {
            using (TextReader publicKeyTextReader = new StringReader(File.ReadAllText(filePath)))
            {
                RsaKeyParameters publicKeyParam = (RsaKeyParameters)new PemReader(publicKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParam);

                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }
    }
}
