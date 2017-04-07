using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataStorage dataStorage;
        private AccountManager accountManager;
        private LoginWindow loginWindow;

        private bool access = false;
        public bool Access {
            get { return access; }
            set
            {
                if (access != value)
                {
                    access = value;
                    OnPropertyChanged("Access");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            dataStorage = new DataStorage();
            accountManager = new AccountManager(dataStorage);
            InitializeComponent();
            DataContext = this;
        }

        private void LoginHandler(object sender, LoginEventArgs e)
        {
            Access = e.Auth;
            Console.WriteLine(Access);
        }

        private void Login()
        {
            loginWindow = new LoginWindow(accountManager);
            this.IsEnabled = false;
            loginWindow.onLogin += LoginHandler;
            loginWindow.Closing += (s, e) =>
            {
                loginWindow.onLogin -= LoginHandler;
                this.IsEnabled = true;
            };
            loginWindow.ShowDialog();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var subs = new List<Subject>();
            subs.Add(new Subject("Maths", 36));
            Teacher t = new Teacher("Fedor", "", "Ilich", new DateTime(1970, 10, 3), Human.SexT.Male, subs);
            JournalTeacherWindow teacherWindow = new JournalTeacherWindow(dataStorage, t);
            teacherWindow.Show();
        }
    }
}
