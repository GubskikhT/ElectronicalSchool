using ElectronicSchool.accounts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ElectronicSchool
{
    public partial class GuestPage : Page
    {
        private LoginCredentionals credits;

        public GuestPage(LoginCredentionals credits)
        {
            this.credits = credits;
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
        }
    }
}
