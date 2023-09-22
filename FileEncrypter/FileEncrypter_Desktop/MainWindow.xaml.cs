using FileHasher;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace FileEncrypter_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public Prompter _prompter { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            btnEncrypt.IsEnabled = false;
            btnDecrypt.IsEnabled = false;
            _prompter = new Prompter(lblPrompter);
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName;
                lblFile.Content = "File: " + Path.GetFileName(FileName);
                Directory = Path.GetDirectoryName(FileName) ?? "\\";
            }
            if (IsFileJson())
            {
                btnDecrypt.IsEnabled = true;
            }
            btnEncrypt.IsEnabled = true;
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            Encrypter encrypter = new Encrypter(_prompter);
            encrypter.Run(FileName);
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Decrypter decrypter = new Decrypter(_prompter);
            decrypter.Run(FileName);
        }

        private bool IsFileJson()
        {
            if(Path.GetExtension(FileName) == ".json")
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
}
