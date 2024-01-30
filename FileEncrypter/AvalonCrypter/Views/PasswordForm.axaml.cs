using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace AvalonCrypter.Views
{
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
            string pass = txtPassword.Text ?? "";
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
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            if (e.Key == Key.Enter)
            {
                Submit();
            }
        }

        private void Submit()
        {
            string pass_1 = txtPassword.Text ?? "";
            string pass_2 = txtPassword2.Text ?? "";
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
