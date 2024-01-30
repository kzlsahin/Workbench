using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncrypterCore
{
    public static class KeyGetter
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
        public static void GetKey(string userPassword, out Byte[] key, int minLength, int maxLength, Encoding enc)
        {
            key = enc.GetBytes(userPassword);
        }
    }
}
