using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ElectronicSchool
{
    public partial class TeacherPage : Page
    {

        public TeacherPage()
        {
            InitializeComponent();
        }

        private void LogutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
        }
    }
}
