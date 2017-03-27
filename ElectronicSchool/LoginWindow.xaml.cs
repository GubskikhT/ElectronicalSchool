using ElectronicSchool;
using ElectronicSchool.accounts;
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

namespace ElectronicSchool
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private AccountManager accountManager;
        public delegate void LoginHandler(object sender, LoginEventArgs args);
        public event LoginHandler onLogin;

        public LoginWindow(AccountManager accountManager)
        {
            this.accountManager = accountManager;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            bool auth = accountManager.Authenticate(new LoginCredentials(usernameTextBox.Text, passwordBox.Password), out id);
            if (auth)
            {
                textLabel.Content = "Login successful!";
                onLogin(this, new ElectronicSchool.LoginEventArgs(true, id));
                Close();
            } else
            {
                textLabel.Content = "Login failed. Please try once more!";
                onLogin(this, new ElectronicSchool.LoginEventArgs(false));
            }
        }
    }
}
