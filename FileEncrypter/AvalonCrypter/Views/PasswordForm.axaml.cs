using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace AvalonCrypter.Views
{
    public partial class PasswordForm : Window
    {
        public string Password { get; set; } = "";
        public bool Result { get; private set; } = false;
        public int MinLength { get; set; }
        public int MaxLength {  get; set; }
        public PasswordForm()
        {
            InitializeComponent();
        }
        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            string pass = txtPassword.Text ?? "";
            lblStatus.Content = "";
            CheckInitialPassword(pass);
        }

        private bool CheckInitialPassword(string pass)
        {
            if (pass.Length < MinLength || pass.Length > MaxLength)
            {
                lblStatus.Content += $"password should be {MinLength}-{MaxLength} letters in lenth!\n";
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
        }
    }
}
