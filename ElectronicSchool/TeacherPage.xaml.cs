using ElectronicJournal;
using ElectronicJournal.data;
using ElectronicSchool.accounts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ElectronicSchool
{
    public partial class TeacherPage : Page
    {
        private LoginCredentionals credits;
        private Person teacher;
        private Subject subject;

        private ObservableCollection<Person> _studentList;
        private ObservableCollection<JournalEntry> _markList;
        private TeacherViewModel tvm;

        public TeacherPage(LoginCredentionals credits)
        {
            this.credits = credits;
            InitializeComponent();
            InitializeObservable();
            tvm = new TeacherViewModel(_studentList, _markList);
            DataContext = tvm;
            MarkComboBox.ItemsSource = Enumerable.Range((int)AppConfiguration.MinMarkValue, (int)AppConfiguration.MaxMarkValue - (int)AppConfiguration.MinMarkValue + 1);
            MarkComboBox.SelectedIndex = 0;
            var teacherId = DataManager.DStorage.Login_Id_Map[credits.Username];
            this.teacher = DataManager.DStorage.Id_Person_Map[teacherId];
            this.subject = DataManager.DStorage.Id_Subject_Map[teacherId];
        }

        private void InitializeObservable()
        {
            _studentList = new ObservableCollection<Person>();
            DataManager.DStorage.GetStudents().ForEach(s => _studentList.Add(s));
            _markList = new ObservableCollection<JournalEntry>();
        }

        private void LogutButton_Click(object sender, RoutedEventArgs e)
        {
            DataManager.SaveStorage();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
        }

        private void AddMarkButton_Click(object sender, RoutedEventArgs e)
        {
            var student = StudentListBox.SelectedItem as Person;
            var mark = new Mark(uint.Parse(MarkComboBox.SelectedValue.ToString()));
            var entry = new JournalEntry(DateTime.Now, student.Id, teacher.Id, subject, mark);
            DataManager.DStorage.Journal.AddEntry(entry);
            _markList.Add(entry);
        }

        private void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var student = StudentListBox.SelectedValue as Person;
            _markList.Clear();
            DataManager.DStorage.Journal.GetEntries(student.Id, subject).ForEach(i => {
                Console.WriteLine(i);
                _markList.Add(i);
            });
        }
    }

    public class TeacherViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Person> _studentList;
        private ObservableCollection<JournalEntry> _markList;

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

        public ObservableCollection<JournalEntry> MarkList
        {
            get
            {
                return _markList;
            }
            set
            {
                if (_markList != value)
                {
                    value = _markList;
                    OnPropertyChanged("MarkList");
                }
            }
        }

        public TeacherViewModel(ObservableCollection<Person> _studentList, ObservableCollection<JournalEntry> _markList)
        {
            this._studentList = _studentList;
            this._markList = _markList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
