using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using FileEncrypterCore;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using Avalonia.Controls.Shapes;
using ReactiveUI;
using System.Linq.Expressions;
using System.ComponentModel;

namespace AvalonCrypter.Views;

public partial class MainView : UserControl, INotifyPropertyChanged
{
    int MAX_PASS_LENGTH = 16;
    int MIN_PASS_LENGTH = 8;
    public string FileName { get; set; } = "";
    private IPrompter _prompter;
    private string _fileContent = "";
    Uri? _lastOutput;
    public Uri? LastOutput
    {
        get
        {
            return _lastOutput;
        }
        private set
        {
            _lastOutput = value;
            OnPropertyChanged(nameof(LastOutput));
        }
    }
    readonly ContentWriter _writer;
    public MainView()
    {
        InitializeComponent();
        btnEncrypt.IsEnabled = false;
        btnDecrypt.IsEnabled = false;
        _prompter = new Prompter(lblPrompter);
        _writer = new();
        DataContext = this;
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

        if (files.Count > 0)
        {
            FileName = files[0].Name;
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            // Reads all the content of file as a text.
            _fileContent = await streamReader.ReadToEndAsync();
        }
        btnEncrypt.IsEnabled = true;
        btnDecrypt.IsEnabled = true;
    }

    private void btnEncrypt_Click(object sender, RoutedEventArgs e)
    {
        _ = Encrypt();
    }
    private async Task Encrypt()
    {
        if (string.IsNullOrEmpty(_fileContent)) return;
        PasswordForm passwordFrom = new();
        passwordFrom.MaxLength = MAX_PASS_LENGTH;
        passwordFrom.MinLength = MIN_PASS_LENGTH;
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && desktop.MainWindow is not null)
        {
            await passwordFrom.ShowDialog(desktop.MainWindow);
        }
        if (passwordFrom.Result)
        {
            var pass = passwordFrom.Password;
            Encrypter encrypter = new Encrypter(_prompter);
            var encryptedContent = encrypter.Run(_fileContent, pass);

            string jsonFileName = $"{FileName}_encrypted.json";

            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null)
                return;
            var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "save out put. Keep default name!",
                DefaultExtension = "json",
                SuggestedFileName = jsonFileName,
            });

            if (file is not null)
            {
                if (await _writer.WriteAsync(file, encryptedContent))
                {
                    _prompter.WriteLine($"written to the file {file.Path}");
                    LastOutput = file.Path;
                }
                else
                {
                    _prompter.WriteLine("Couldn't write to file.");
                    _prompter.WriteLine(_writer.ErrMessage);
                }
            }
            else
            {
                _prompter.WriteLine("Encryption is canceled.");
            }
        }
    }

    private void btnDecrypt_Click(object sender, RoutedEventArgs e)
    {
        _ = Decrypt();
    }
    private async Task Decrypt()
    {
        if (string.IsNullOrEmpty(_fileContent)) return;

        PasswordForm passwordFrom = new();
        passwordFrom.MaxLength = MAX_PASS_LENGTH;
        passwordFrom.MinLength = MIN_PASS_LENGTH;
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && desktop.MainWindow is not null)
        {
            await passwordFrom.ShowDialog(desktop.MainWindow);
        }
        if (passwordFrom.Result)
        {
            var pass = passwordFrom.Password;

            Decrypter decrypter = new Decrypter(_prompter);
            string content = decrypter.Run(_fileContent, pass);

            if (string.IsNullOrEmpty(content))
            {
                _prompter.WriteLine("empty file!");
                return;
            }
            string decryptedFilename = $"{FileName}_decrypted.txt";

            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null)
                return;
            var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "save decrypted file",
                DefaultExtension = "txt",
                SuggestedFileName = decryptedFilename,
            });

            if (file is not null)
            {
                if (await _writer.WriteAsync(file, content))
                {
                    _prompter.WriteLine($"written to the file {file.Path}");
                    LastOutput = file.Path;
                }
                else
                {
                    _prompter.WriteLine("Couldn't write to file.");
                    _prompter.WriteLine(_writer.ErrMessage);
                }
            }
            else
            {
                _prompter.WriteLine("Decryption is canceled.");
            }
        }
        else
        {
            _prompter.WriteLine("Decryption is canceled.");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
