using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FileEncrypter_Desktop
{
    /// <summary>
    /// Interaction logic for PasswordForm.xaml
    /// </summary>
    public partial class PasswordForm : Window
    {
        public string Password { get; set; }
        public bool Result = false;
        private int _minLength;
        private int _maxLength;
        public PasswordForm(int minLength, int mnacLength)
        {
            InitializeComponent();
            _minLength = minLength;
            _maxLength = mnacLength;
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            string pass = txtPassword.Password;
            lblStatus.Content = "";
            CheckInitialPassword(pass);

        }

        private bool CheckInitialPassword(string pass)
        {
            if (pass.Length < _minLength || pass.Length > _maxLength)
            {
                lblStatus.Content += $"password should be {_minLength}-{_maxLength} letters in lenth!\n";
                return false;
            }
            return true;
        }

        private bool CheckPasswords(string pass_1, string pass_2)
        {
            lblStatus.Content = "";
            if (!CheckInitialPassword(pass_1))
            {
                return false;
            }
            if (!pass_1.Equals(pass_2))
            {
                lblStatus.Content += "passwords do not match\n";
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Submit();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                this.Close();
            }
            if(e.Key == Key.Enter)
            {
                Submit();
            }
        }

        private void Submit()
        {
            string pass_1 = txtPassword.Password;
            string pass_2 = txtPassword2.Password;
            if (CheckPasswords(pass_1, pass_2))
            {
                Password = pass_1;
                this.Result = true;
                this.Close();
            }
            return;
        }
    }
}
