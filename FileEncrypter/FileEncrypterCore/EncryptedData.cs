using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncrypterCore
{
    public class EncryptedData
    {
        public byte[] InitializationVector { get; set; }
        public byte[] Content { get; set; }
        public string Salt { get; set; }
    }
}
