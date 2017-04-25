using ElectronicJournal;
using ElectronicJournal.data;
using ElectronicSchool.accounts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static ElectronicSchool.Person;

namespace ElectronicSchool
{

    public partial class AdministratorPage : Page
    {
        private ObservableCollection<ExtendedPerson> _personList;
        private ObservableCollection<Person> _studentList;
        private LoginCredentionals credits;
        private AdministrativeViewModel avm;

        public AdministratorPage(LoginCredentionals credits)
        {
            this.credits = credits;
            InitializeComponent();
            InitializeData();
            var id = DataManager.DStorage.Login_Id_Map[credits.Username];
            var person = DataManager.DStorage.Id_Person_Map[id];
            AdminLabel.Content = "Administrator [" + person.ToShortString() + "]";
            avm = new AdministrativeViewModel(_personList, _studentList);
            DataContext = avm;
            PositionComboBox.ItemsSource = Enum.GetValues(typeof(Position));
            SexComboBox.ItemsSource = Enum.GetValues(typeof(SexT));
            SubjectComboBox.ItemsSource = Enum.GetValues(typeof(Subject));
            SwitchSubject(false);
            SwitchGuest(false);
        }

        private void InitializeData()
        {
            _personList = new ObservableCollection<ExtendedPerson>();
            _studentList = new ObservableCollection<Person>();
            var ids = DataManager.DStorage.Id_Person_Map.Keys;
            var currentId = DataManager.DStorage.Login_Id_Map[credits.Username];
            foreach (var id in ids)
            {
                var person = DataManager.DStorage.Id_Person_Map[id];
                var position = DataManager.DStorage.Id_Position_Map[id];
                if (id != currentId)
                    _personList.Add(new ExtendedPerson(person, position));
                if (position == Position.Student)
                    _studentList.Add(person);
            }
        }

        private void SwitchSubject(bool on)
        {
            SubjectLabel.Visibility = on ? Visibility.Visible : Visibility.Hidden;
            SubjectComboBox.Visibility = on ? Visibility.Visible : Visibility.Hidden;
            SubjectComboBox.SelectedIndex = on ? -1 : 0;
        }

        private void SwitchGuest(bool on)
        {
            GuestLabel.Visibility = on ? Visibility.Visible : Visibility.Hidden;
            GuestComboBox.Visibility = on ? Visibility.Visible : Visibility.Hidden;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            DataManager.SaveStorage();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
        }

        private void PositionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            SwitchSubject(false);
            SwitchGuest(false);
            if (cmb.SelectedValue != null && (Position)cmb.SelectedValue == Position.Teacher)
                SwitchSubject(true);
            else if (cmb.SelectedValue != null && (Position)cmb.SelectedValue == Position.Guest)
                SwitchGuest(true);
        }

        private void Reset()
        {
            UserNameTextBox.Clear();
            PasswordTextBox.Clear();
            NameTextBox.Clear();
            SecondNameTextBox.Clear();
            SurnameTextBox.Clear();
            BirthDayDatePicker.ClearValue(DatePicker.SelectedDateProperty);
            SexComboBox.ClearValue(ComboBox.SelectedItemProperty);
            PositionComboBox.ClearValue(ComboBox.SelectedItemProperty);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newUserCredits = new LoginCredentionals(avm.UserName, avm.Password);
            var p = new Person(avm.Name, avm.SecondName, avm.Surname, avm.Birthday, (SexT)avm.SexIndex);
            var pos = (Position)avm.PositionIndex;
            DataManager.DStorage.RegisterNewUser(credits, newUserCredits, pos, p);
            _personList.Add(new ExtendedPerson(p, pos));
            if ((Position)avm.PositionIndex == Position.Teacher)
            {
                DataManager.DStorage.RegisterTeacher(credits, p.Id, (Subject)avm.SubjectIndex);
            }
            else if ((Position)avm.PositionIndex == Position.Guest)
            {
                var studentId = _studentList[avm.StudentIndex].Id;
                DataManager.DStorage.RegisterGuest(credits, studentId, p.Id);
            }
            Reset();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            DataManager.DStorage.RemoveUser(credits, (PersonListBox.SelectedValue as ExtendedPerson).Person.Id);
            _personList.RemoveAt(PersonListBox.SelectedIndex);

        }
    }

    public class AdministrativeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ExtendedPerson> _personList;
        private ObservableCollection<Person> _studentList;

        public ObservableCollection<ExtendedPerson> PersonList
        {
            get
            {
                return _personList;
            }
            set
            {
                if (_personList != value)
                {
                    value = _personList;
                    OnPropertyChanged("PersonList");
                }
            }
        }

        public ObservableCollection<Person> StudentList
        {
            get
            {
                return _studentList;
            }
            set
            {
                if (_studentList != value)
                {
                    value = _studentList;
                    OnPropertyChanged("StudentList");
                }
            }
        }

        private string _userName = "";
        private string _password = "";
        private string _name = "";
        private string _secondName = "";
        private string _surname = "";
        private int _sexIndex = -1;
        private int _positionIndex = -1;
        private int _subjectIndex = -1;
        private int _studentIndex = -1;
        private DateTime _birthday;

        public AdministrativeViewModel(ObservableCollection<ExtendedPerson> _personList, ObservableCollection<Person> _studentList)
        {
            this._personList = _personList;
            this._studentList = _studentList;
        }

        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (value > DateTime.Now || value < new DateTime(1900, 1, 1))
                    throw new Exception("Birthday should be > 01.01.1900");
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged("Birthday");
                }
            }
        }

        public int SexIndex
        {
            get
            {
                return _sexIndex;
            }
            set
            {
                if (value == -1)
                    throw new Exception("Sex should be selected.");
                if (_sexIndex != value)
                {
                    _sexIndex = value;
                    OnPropertyChanged("SexIndex");
                }
            }
        }

        public int PositionIndex
        {
            get
            {
                return _positionIndex;
            }
            set
            {
                if (value == -1)
                    throw new Exception("Position should be selected.");
                if (_positionIndex != value)
                {
                    _positionIndex = value;
                    OnPropertyChanged("PositionIndex");
                }
            }
        }

        public int SubjectIndex
        {
            get
            {
                return _subjectIndex;
            }
            set
            {
                if (value == -1)
                    throw new Exception("Position should be selected.");
                if (_subjectIndex != value)
                {
                    _subjectIndex = value;
                    OnPropertyChanged("SubjectIndex");
                }
            }
        }

        public int StudentIndex
        {
            get
            {
                return _studentIndex;
            }
            set
            {
                if (value == -1)
                    throw new Exception("Student should be selected.");
                if (_studentIndex != value)
                {
                    _studentIndex = value;
                    OnPropertyChanged("StudentIndex");
                }
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Username can not be empty.");
                if (value.Length > 12)
                    throw new Exception("Userename can not be longer than 12 chars");
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Password can not be empty.");
                if (value.Length > 12 || value.Length < 5)
                    throw new Exception("Password can not be longer than 12 chars or shorter than 5 chars");
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name can not be empty.");
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Second name can not be empty.");
                if (_secondName != value)
                {
                    _secondName = value;
                    OnPropertyChanged("SecondName");
                }
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Surname can not be empty.");
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
