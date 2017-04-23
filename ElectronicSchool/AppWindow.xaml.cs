using ElectronicJournal.data;
using System;
using System.Windows;

namespace ElectronicSchool
{

    public partial class AppWindow : Window
    {

        public AppWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new LoginPage());
        }

        private void mainFrame_ContentRendered(object sender, EventArgs e)
        {
            mainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataManager.SaveStorage();
        }
    }
}
