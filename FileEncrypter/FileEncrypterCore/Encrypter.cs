using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static FileEncrypterCore.FileIO;

namespace FileEncrypterCore
{
    public class Encrypter
    {
        public const int MIN_PASS_LENGTH = 8;
        public const int MAX_PASS_LENGTH = 16;

        public IPrompter _prompter { get; private set; }
        public Encrypter(IPrompter prompter)
        {
            _prompter = prompter;
        }

        public void Run(string path, string userPassword)
        {
            string content = FileIO.GetFileContent(path, _prompter);

            var encoding = Encoding.UTF8;
            KeyGetter.GetKey(userPassword, out Byte[] key, 8, 16, encoding);

            string salt = "jnaljfzh";
            byte[] encrypted;
            byte[] kekeySalted = new byte[16];
            kekeySalted = KeyGetter.CreateKey16(key, salt, encoding);

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
