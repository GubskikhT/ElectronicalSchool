using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    public class DataManager
    {

        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        List<Subject> subjects = new List<Subject>();
        Journal journal = new Journal();

        public Journal Journal
        {
            get
            {
                return journal;
            }
        }

        public List<Subject> Subjects
        {
            get
            {
                return subjects;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return teachers;
            }
        }

        public List<Student> Students
        {
            get
            {
                return students;
            }
        }

        public void addStudent(Student student)
        {
            Students.Add(student);
        }

        public void printAllStudents()
        {
            foreach (Student st in Students)
            {
                Console.WriteLine(st);
            }
        }
    }
}
