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

        public void addStudent(Student student)
        {
            students.Add(student);
        }

        public void printAllStudents()
        {
            foreach (Student st in students)
            {
                Console.WriteLine(st);
            }
        }
    }
}
