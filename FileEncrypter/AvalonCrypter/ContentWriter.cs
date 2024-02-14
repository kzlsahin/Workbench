using Avalonia.Controls;
using Avalonia.Platform.Storage;
using FileEncrypterCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonCrypter
{
    internal class ContentWriter
    {
        public string ErrMessage { get; private set; } = "";

        public async Task<bool> WriteAsync(IStorageFile file, string content)
        {
            ErrMessage = "";
            try
            {
                using var fs = await file.OpenWriteAsync();
                using var sr = new StreamWriter(fs);
                await sr.WriteAsync(content);
                return true;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message + "\nsource:\n" + ex.Source;
                return false;
            }
        }
    }
}
