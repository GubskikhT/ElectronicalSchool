using ElectronicJournal;
using ElectronicJournal.data;
using ElectronicJournal.logging;
using ElectronicSchool.accounts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ElectronicSchool
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            var credits = new LoginCredentionals(usernameTextBox.Text, passwordBox.Password);
            bool auth = AccountManager.Authenticate(credits, out id);
            if (auth)
            {
                Position pos;
                if (DataManager.DStorage.Id_Position_Map.TryGetValue(id, out pos)) {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    switch (pos)
                    {
                        case Position.Guest:
                        case Position.Student:
                            Logger.Info("Navigating to guest page.");
                            nav.Navigate(new GuestPage());
                            return;
                        case Position.Teacher:
                            Logger.Info("Navigating to teacher page.");
                            nav.Navigate(new TeacherPage());
                            return;
                        case Position.Administrator:
                            Logger.Info("Navigating to administrator page.");
                            nav.Navigate(new AdministratorPage(credits));
                            return;
                        default:
                            return;
                    }
                }
                else
                {
                    Logger.Warn("Can not determine position of person [" + credits.Username + "].");
                }
            }
            else
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                textLabel.Content = "Login failed. Please try once more!";
            }
        }
    }
}
