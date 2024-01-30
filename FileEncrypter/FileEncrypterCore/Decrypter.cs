using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileEncrypterCore
{
    public class Decrypter
    {
        public IPrompter _prompter { get; private set; }
        public Decrypter(IPrompter prompter)
        {
            _prompter = prompter;
        }

        public void Run(string content, string path, string userPassword)
        {
            var encoding = Encoding.UTF8;
            KeyGetter.GetKey(userPassword, out Byte[] key, 8, 16, encoding);

            EncryptedData data = JsonSerializer.Deserialize<EncryptedData>(content) ?? new EncryptedData();

            if (String.IsNullOrEmpty(data.Salt))
            {
                _prompter.WriteLine("inconsistn file! Cancelled");
            }
            if (data.Content?.Length == null || data.InitializationVector?.Length == null)
            {
                _prompter.WriteLine("inconsistn file! Cancelled");
            }

            string salt = data.Salt;
            var saltedKey = KeyGetter.CreateKey16(key, salt, encoding);
            var IV = data.InitializationVector;
            string plaintext = string.Empty;
            using (Aes aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(saltedKey, IV))
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
            string directory = Path.GetDirectoryName(path) ?? String.Empty;
            string fileName = Path.GetFileNameWithoutExtension(path) + "_decrypted.txt";
            string outputFile = Path.Combine(directory, fileName);
            File.WriteAllText(outputFile, plaintext);
        }
    }
}
