using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
namespace Pharmacy.Utility
{
    public class Encryption
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public Encryption(string key, string iv)
        {
            _key = Encoding.UTF8.GetBytes(key);
            _iv = Encoding.UTF8.GetBytes(iv);
        }

        public string DecodeFromByteArray(byte[] cipherTextVal)
        {
            if (cipherTextVal == null || cipherTextVal.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherTextVal));
            }
            string plaintext;

            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = _key;
                rijAlg.IV = _iv;
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    using (var msDecrypt = new MemoryStream(cipherTextVal))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Debug.Write(exception);
                    plaintext = "keyError";
                }
            }
            return plaintext;
        }

        public string DecodeFromBase64String(string cipherTextVal)
        {
            return DecodeFromByteArray(Convert.FromBase64String(cipherTextVal));
        }

        public byte[] EncodeToByteArray(string plainText)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(plainText));
            }
            byte[] encrypted;
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = _key;
                rijAlg.IV = _iv;

                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        public string EncodeToBase64String(string plainText)
        {
            return Convert.ToBase64String(EncodeToByteArray(plainText));
        }

        public string DecryptConnectionString(string connectionString)
        {
            var patterns = new List<string> { "data source", "initial catalog", "User ID", "Password" };
            foreach (var pattern in patterns)
            {
                var regex = new Regex(pattern + "=(.+?);");
                var match = regex.Match(connectionString);
                if (!match.Success) continue;
                var result = match.Result("$1");
                var decrypted = DecodeFromBase64String(result);
                connectionString = connectionString.Replace(result, decrypted);
            }
            return connectionString;
        }
    }
}
