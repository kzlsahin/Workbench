using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using FileEncrypterCore;
using System.IO;
using System.Diagnostics;

namespace AvalonCrypter.Views;

public partial class MainView : UserControl
{
    public string FileName { get; set; } = "";
    public string Directory { get; set; } = "";
    private IPrompter _prompter;
    private string _fileContent;
    private Window _ownerWindow;
    public MainView()
    {
        InitializeComponent();
        btnEncrypt.IsEnabled = false;
        btnDecrypt.IsEnabled = false;
        _prompter = new Prompter(lblPrompter);
    }
    private async void btnSelectFile_Click(object sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel is null)
            return;
        // Start async operation to open the dialog.
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        if (files.Count > 1)
        {
            FileName = files[0].Name;
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            // Reads all the content of file as a text.
            _fileContent = await streamReader.ReadToEndAsync();
        }
        if (IsFileJson())
        {
            btnDecrypt.IsEnabled = true;
        }
        btnEncrypt.IsEnabled = true;
    }

    private void btnEncrypt_Click(object sender, RoutedEventArgs e)
    {
        PasswordForm passwordFrom = new(Encrypter.MIN_PASS_LENGTH, Encrypter.MAX_PASS_LENGTH);
        passwordFrom.Show();
        if (passwordFrom.Result == true)
        {
            var pass = passwordFrom.Password;
            Encrypter encrypter = new Encrypter(_prompter);
            encrypter.Run(FileName, FileName, pass);
        }
        else
        {
            _prompter.WriteLine("Encryption is canceled.");
        }
    }

    private void btnDecrypt_Click(object sender, RoutedEventArgs e)
    {
        PasswordForm passwordFrom = new(Encrypter.MIN_PASS_LENGTH, Encrypter.MAX_PASS_LENGTH);
        passwordFrom.Show();
        if (passwordFrom.Result == true)
        {
            var pass = passwordFrom.Password;
            Decrypter decrypter = new Decrypter(_prompter);
            decrypter.Run(FileName, FileName, pass);
        }
        else
        {
            _prompter.WriteLine("Decryption is canceled.");
        }
    }

    private bool IsFileJson()
    {
        if (Path.GetExtension(FileName) == ".json")
        {
            return true;
        }
        return false;
    }

    private void btnOpenDirectory_Click(object sender, RoutedEventArgs e)
    {
        Process.Start("explorer.exe", Directory);
    }
}
