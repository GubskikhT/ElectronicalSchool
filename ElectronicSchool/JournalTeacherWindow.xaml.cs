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
    /// Логика взаимодействия для JournalTeacherWindow.xaml
    /// </summary>
    public partial class JournalTeacherWindow : Window
    {
        private DataStorage dataStorage;

        private List<Student> students;
        private List<JournalEntry> journalEntries;
        private Teacher teacher;

        private void CreateMockStudents()
        {
            students = new List<Student>();
            Group gr1 = new Group(10, 'A', "phys");
            students.Add(new Student("Ivan", "", "Ivanov", new DateTime(1993, 12, 2), Human.SexT.Male, gr1));
            students.Add(new Student("Ksenia", "", "Trubova", new DateTime(1993, 10, 2), Human.SexT.Female, gr1));
        }

        private void CreateMockJournalEntries(Teacher teacher)
        {
            journalEntries = new List<JournalEntry>();
            journalEntries.Add(new JournalEntry(DateTime.Now, students[0], teacher, teacher.TeachedSubjects[0], new Mark(5)));
            journalEntries.Add(new JournalEntry(DateTime.Now, students[1], teacher, teacher.TeachedSubjects[0], new Mark(3)));
            journalEntries.Add(new JournalEntry(DateTime.Now, students[1], teacher, teacher.TeachedSubjects[0], new Mark(2)));
            journalEntries.Add(new JournalEntry(DateTime.Now, students[1], teacher, teacher.TeachedSubjects[0], new Mark(4)));
        }

        public JournalTeacherWindow(DataStorage dataStorage, Teacher teacher)
        {
            this.dataStorage = dataStorage;
            this.teacher = teacher;
            InitializeComponent();
            CreateMockStudents();
            CreateMockJournalEntries(teacher);
            studentsListBox.ItemsSource = students;
            markValueComboBox.ItemsSource = Enumerable.Range(1, 5).ToList();
        }

        private void addMarkButton_Click(object sender, RoutedEventArgs e)
        {
            if (markValueComboBox.SelectedIndex != -1)
            {
                var mark = new Mark(Convert.ToInt32(markValueComboBox.SelectedItem));
                var entry = new JournalEntry(DateTime.Now, students[studentsListBox.SelectedIndex], teacher, teacher.TeachedSubjects[0], mark);
                journalEntries.Add(entry);
                updateJournalEntries();
            }
        }

        private void updateJournalEntries()
        {
            var student = students[studentsListBox.SelectedIndex];
            var entries = journalEntries.Where(i => i.Student == student);
            marksListBox.ItemsSource = entries;
        }

        private void studentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateJournalEntries();
        }
    }
}
