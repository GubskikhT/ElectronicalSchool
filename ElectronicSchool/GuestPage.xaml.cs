using ElectronicJournal.data;
using ElectronicSchool.accounts;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ElectronicSchool
{
    public partial class GuestPage : Page
    {
        private LoginCredentionals credits;
        private Person student;

        public GuestPage(LoginCredentionals credits)
        {
            this.credits = credits;
            var studentId = DataManager.DStorage.Login_Id_Map[credits.Username];
            this.student = DataManager.DStorage.Id_Person_Map[studentId];
            InitializeComponent();
            MarkLabel.Content = "Marks for student [" + student + "]:";
            var entries = DataManager.DStorage.Journal.GetEntries(studentId);
            var displayEntries = entries.ConvertAll(e => new DisplayEntry(e.Time, e.Subject, DataManager.DStorage.Id_Person_Map[e.TeacherId], e.Mark));
            MarkGrid.ItemsSource = displayEntries;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
        }

        class DisplayEntry
        {
            public DateTime Date { get; private set; }
            public Subject Subject { get; private set; }
            public Person Teacher { get; private set; }
            public Mark Mark { get; private set; }

            public DisplayEntry(DateTime date, Subject subject, Person teacher, Mark mark)
            {
                this.Date = date;
                this.Subject = subject;
                this.Teacher = teacher;
                this.Mark = mark;
            }
        }
    }
}
