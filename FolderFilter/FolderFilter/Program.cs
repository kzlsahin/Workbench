// See https://aka.ms/new-console-template for more information
using System.Linq;

if (args.Length < 3)
{
    Console.WriteLine("Hello, User!");
    Console.WriteLine("Requires 3 arguments");
    PrintHelp();
    return;
}
else if(args.Length == 1)
{
    if(args[0] == "-h" || args[0] == "--help")
    {
        PrintHelp();
    }
    return;
}

string dir_filterFolder = args[0];
string dir_refFolder = args[1];
string dir_outFolder = String.Empty;
if(args.Length == 2)
{
    dir_outFolder = dir_filterFolder + "Filtered";
}
else
{
    dir_outFolder = args[2];
}

if (!Directory.Exists(dir_filterFolder))
{
    throw new Exception("path of folder to be filtered is not valid");
}
if (!Directory.Exists(dir_refFolder))
{
    throw new Exception("path of reference folder is not valid");

}

while (CheckDestinationFolder(dir_outFolder) == false)
{
    Console.WriteLine("Enter new destination folder path:");
    dir_outFolder = Console.ReadLine() ?? string.Empty;
}



    List<string> refFileList = Directory.GetFiles(dir_refFolder).Select(x => Path.GetFileName(x)).ToList();
    List<string> filterFileList = Directory.GetFiles(dir_filterFolder).Select(x => Path.GetFileName(x)).ToList();
    List<string> newFileList = filterFileList.Where(x => !refFileList.Contains(x)).ToList();

    foreach (string file in newFileList)
    {
        Console.WriteLine("copying " + file);
        string from = Path.Combine(dir_filterFolder, file);
        string to = Path.Combine(dir_outFolder, file);
        File.Copy(from, to);
    }

static bool CheckDestinationFolder(string dir_outFolder)
{
    if (!Directory.Exists(dir_outFolder))
    {
        Directory.CreateDirectory(dir_outFolder);
        return true;
    }
    else
    {
        int numberOfFiles = Directory.GetFiles(dir_outFolder).Length;
        Console.WriteLine("The destination directory already exist.");
        Console.WriteLine($"Contains {numberOfFiles} files.");
        bool clearFolder = AskToClearFolder(dir_outFolder);
        if (clearFolder)
        {
            Directory.Delete(dir_outFolder, true);
            Directory.CreateDirectory(dir_outFolder);
        }
        return clearFolder;
    }
}
static void PrintHelp()
{
    Console.WriteLine("- Help -");
    Console.WriteLine("this command creates a new folder and copies files in target folder to that folder where a file with the same name does not exist in reference folder.");
    Console.WriteLine("----------------------------------------------------------");
    Console.WriteLine("usage: [path of this exe] filterFolder RefFolder [output]");
    Console.WriteLine("- filterFolder : path of folder to be filtered from which files will be coppied to destination folder");
    Console.WriteLine("- RefFolder : path of reference folder. The files of target folder that the reference folder has the same name with, will be excluded from the copy");
    Console.WriteLine("- output : (optional)path of output folder to which files will be copied");
    Console.WriteLine("----------------------------------------------------------");
}

static bool AskToClearFolder(string dest)
{
    Console.WriteLine($"going to clear the folder {dest}");    
    string res = string.Empty;
    while(true)
    {
        Console.WriteLine($"Do you want to clear the files?[y|n]");
        res = Console.ReadLine() ?? string.Empty;
        if (res == "y" || res == "Y") { res = "y"; break; }
        if (res == "n" || res == "N") { res = "n"; break; }
        Console.WriteLine("couldn't resolved the answer!");
    }
    switch (res)
    {
        case "y":
            return true;
        case "n":
            return false;
        default:
            Console.WriteLine("couldn't resolved the answer!");
            return AskToClearFolder(dest);
    }
}