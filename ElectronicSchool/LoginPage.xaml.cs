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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectronicSchool
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly AccountManager accountManager;

        public LoginPage(AccountManager accountManager)
        {
            this.accountManager = accountManager;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            bool auth = accountManager.Authenticate(new accounts.LoginCredentionals(usernameTextBox.Text, passwordBox.Password), out id);
            if (auth)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new TeacherPage(accountManager));
            }
            else
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                textLabel.Content = "Login failed. Please try once more!";
            }
        }
    }
}
