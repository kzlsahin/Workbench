using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileEncrypterCore
{
    public class Encrypter
    {
        private readonly IPrompter _prompter;
        public Encrypter(IPrompter prompter)
        {
            _prompter = prompter;
        }

        public string Run(string content, string path, string userPassword)
        {
            var encoding = Encoding.UTF8;
            KeyGetter.GetKey(userPassword, out Byte[] key, 8, 16, encoding);

            string salt = "jnaljfzh";
            byte[] encrypted;
            byte[] kekeySalted = KeyGetter.CreateKey16(key, salt, encoding);

            EncryptedData encryptedData = new EncryptedData();
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = kekeySalted;
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
            string str = JsonSerializer.Serialize(encryptedData);
            return str;
        }
    }
}
