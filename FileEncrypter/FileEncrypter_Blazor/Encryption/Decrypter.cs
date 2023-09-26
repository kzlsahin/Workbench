using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileHasher
{
    internal class Decrypter
    {
        public Stream Run(ref string file_name, string content, string pass)
        {
            if (pass == null) return null;
            if (pass.Length > 15 || pass.Length < 8) return null;

            var encoding = Encoding.UTF8;
            var password = encoding.GetBytes(pass);
            EncryptedData data = null;
            try
            {
                data = JsonSerializer.Deserialize<EncryptedData>(content) ?? new EncryptedData();
            }
            catch
            {
                return null;
            }
            string salt = data.Salt;
            byte[] key = InputHelpers.CreateKey16(password, salt, encoding);
            var IV = data.InitializationVector;
            string plaintext = string.Empty;
            using (Aes aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, IV))
                {
                    using (MemoryStream msDecrypt = new MemoryStream(data.Content))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }

            string fileName = Path.GetFileNameWithoutExtension(file_name);
            file_name = fileName + "_decrypted.txt";
            MemoryStream stream = new MemoryStream(encoding.GetBytes(plaintext));
            return stream;
        }
    }
}
