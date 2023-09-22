using FileEncrypter_Desktop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileHasher
{
    internal class Decrypter
    {
        public Prompter _prompter { get; private set; }
        public Decrypter(Prompter prompter)
        {
            _prompter = prompter;
        }

        public void Run(string path)
        {
            string content = InputHelpers.GetFileContent(path);
            _prompter.WriteLine("Getting password.");

            var encoding = Encoding.UTF8;
            int res = PasswordGetter.GetKey(out Byte[] password, 8, 16, encoding);

            if(res != PasswordGetter.SUCCESS)
            {
                _prompter.WriteLine("Decryption is canceled.");
                return;
            }
            _prompter.WriteLine("Valid password.");
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
            var key = PasswordGetter.CreateKey16(password, salt, encoding);
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
            string directory = Path.GetDirectoryName(path) ?? String.Empty;
            string fileName = Path.GetFileNameWithoutExtension(path) + "_decrypted.txt";
            string outputFile = Path.Combine(directory, fileName);
            File.WriteAllText(outputFile, plaintext);
        }
    }
}
