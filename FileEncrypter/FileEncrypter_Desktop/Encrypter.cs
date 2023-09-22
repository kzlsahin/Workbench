using FileEncrypter_Desktop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileHasher
{
    internal class Encrypter
    {
        public Prompter _prompter { get; private set; }
        public Encrypter(Prompter prompter)
        {
            _prompter = prompter;
        }

        public void Run(string path)
        {
            string content = InputHelpers.GetFileContent(path);
            _prompter.WriteLine("Getting password.");

            var encoding = Encoding.UTF8;
            int res = PasswordGetter.GetKey(out Byte[] password, 8, 16, encoding);
            if (res != PasswordGetter.SUCCESS)
            {
                _prompter.WriteLine("Encryption is canceled");
                return;
            }

            string salt = "jnaljfzh";
            byte[] encrypted;
            byte[] key = new byte[16];
            key = PasswordGetter.CreateKey16(password, salt, encoding);

            EncryptedData encryptedData = new EncryptedData();
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                encryptedData.InitializationVector = aesAlg.IV;
                encryptedData.Salt = salt;
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            sw.Write(content);
                        }
                        encrypted = msEncrypt.ToArray();
                        encryptedData.Content = encrypted;
                    }
                }
            }
            string directory = Path.GetDirectoryName(path) ?? string.Empty;
            string fileName = Path.GetFileNameWithoutExtension(path);
            string OutputFile = Path.Combine(directory, $"{fileName}_encrypted");
            //using (FileStream fs = File.Open(OutputFile, FileMode.Create))
            //{
            //        fs.Write(encrypted);
            //}
            string jsonFileName = OutputFile + ".json";
            string str = JsonSerializer.Serialize(encryptedData);
            File.WriteAllText(jsonFileName, str);

            _prompter.WriteLine("file is written to " + OutputFile);
        }
    }
}
