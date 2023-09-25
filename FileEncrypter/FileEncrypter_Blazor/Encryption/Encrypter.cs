using FileEncrypter_Blazor;
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
        public Encrypter()
        {
        }

        public Stream Run(ref string file_name, string content, string pass)
        {
            if (pass == null) return null;
            if (pass.Length > 15 || pass.Length < 8) return null;

            var encoding = Encoding.UTF8;
            var password = encoding.GetBytes(pass);

            string salt = "jnaljfzh";
            byte[] encrypted;
            byte[] key = CreateKey16(password, salt, encoding);

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
            string fileName = Path.GetFileNameWithoutExtension(file_name);
            //using (FileStream fs = File.Open(OutputFile, FileMode.Create))
            //{
            //        fs.Write(encrypted);
            //}
            file_name = fileName + "_encrypted" + ".json";
            string str = JsonSerializer.Serialize(encryptedData);
            MemoryStream stream = new MemoryStream(encoding.GetBytes(str));
            return stream;
        }
        private static Byte[] CreateKey16(byte[] pass, string salt, Encoding encoding)
        {
            byte[] key = new byte[16];
            byte[] saltBytes = encoding.GetBytes(salt);
            int j = 0;
            int passLength = pass.Length;
            for (int i = 0; i < 16; i++)
            {
                if (i < passLength)
                {
                    key[i] = pass[i];
                }
                else
                {
                    key[i] = saltBytes[j++];
                }
            }
            return key;
        }
    }
}
