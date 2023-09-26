using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher
{
    internal static class InputHelpers
    {
        internal static Byte[] CreateKey16(byte[] pass, string salt, Encoding encoding)
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
        public static string GetFileContent(string path)
        {
            string content = string.Empty;
            try
            {
                if (File.Exists(path))
                {
                    content = File.ReadAllText(path);
                }
                else
                {
                    Console.WriteLine("the file doesn't exist");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("path value is not valid");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory couldn't be found or access denied!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File couldn't be found or access denied!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("the path is too long");
            }
            return content;
        }


    }
}
