using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher
{
    internal static class InputHelpers
    {
        public static bool RequestYesNo(string messege, char yes, char no)
        {
            Console.WriteLine(messege + $"({yes}/{no})");

            char ans = Console.ReadKey().KeyChar;

            while (ans != yes && ans != no)
            {
                Console.WriteLine($"Girdiniz yorumlanamadı. Lütfen {yes}/{no} ile cevap veriniz.");
                ans = Console.ReadKey().KeyChar;
            }

            if (ans == yes) return true;
            return false;
        }
        static void RequestEntryDouble(string messege, out double userInput)
        {
            Console.WriteLine(messege);
            Console.WriteLine("sayısal bir değer giriniz");

            while (!Double.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, null, out userInput))
            {
                Console.WriteLine("Girdiniz sayısal bir değer değil. sayısal bir değer giriniz (!! ondalık ayraç olarak nokta kulanın !!)");
            }
            Console.WriteLine($"{userInput} is entered");
        }

        public static int RequestEntryOption(string messege, int[] cases)
        {
            Console.WriteLine(messege);
            Console.WriteLine("seçeneklerden birisini giriniz.");
            int userInput;

            while (!int.TryParse(Console.ReadLine(), out userInput) || !cases.Contains(userInput))
            {
                Console.Write("lütfen");
                foreach (int i in cases) Console.Write(", " + i + " ");
                Console.WriteLine("seçeneklerinden birini giriniz ");
            }

            Console.WriteLine($"{userInput} is entered");
            return userInput;
        }

        public static string GetFileContent(string message, out string path)
        {
            string content = string.Empty;
            bool pathOk = false;
            do
            {
                Console.WriteLine(message);

                path = Console.ReadLine() ?? String.Empty;

                try
                {
                    content = File.ReadAllText(path);
                    pathOk = true;
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
            } while (pathOk == false);

            return content;
        }


    }
}
