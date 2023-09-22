using FileEncrypter_Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher
{
    internal static class PasswordGetter
    {
        public static readonly int CANCEL = 1;
        public static readonly int SUCCESS = 2;

        public static Byte[] CreateKey16(byte[] pass, string salt, Encoding encoding)
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
        public static int GetKey(out Byte[] key, int minLength, int maxLength, Encoding enc)
        {
            PasswordForm passwordFrom = new(minLength, maxLength);
            passwordFrom.ShowDialog();
            if(passwordFrom.Result == true)
            {
                string pass = passwordFrom.Password;
                key = enc.GetBytes(pass);
                return SUCCESS;
            }
            key = new byte[0];
            return CANCEL;
        }

        private static bool AskKey(out string key)
        {
            key = Console.ReadLine();
            Console.WriteLine("please repeat your pass!");
            string check = Console.ReadLine();
            if (key == check)
            {
                Console.WriteLine("Key is taken.");
                return true;
            }
            key = string.Empty;
            return false;
        }

    }
}
