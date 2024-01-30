using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncrypterCore
{
    public static class FileIO
    {
        public static string GetFileContent(string path, IPrompter prompter)
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
                    prompter.WriteLine("the file doesn't exist");
                }
            }
            catch (ArgumentException)
            {
                prompter.WriteLine("path value is not valid");
            }
            catch (DirectoryNotFoundException)
            {
                prompter.WriteLine("Directory couldn't be found or access denied!");
            }
            catch (FileNotFoundException)
            {
                prompter.WriteLine("File couldn't be found or access denied!");
            }
            catch (PathTooLongException)
            {
                prompter.WriteLine("the path is too long");
            }
            return content;
        }
    }
}
