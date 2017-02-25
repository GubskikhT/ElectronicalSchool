using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    class TestRunner
    {
        static void Main(string[] args)
        {
            Human h = new Human("Ivan", "Ivanovich", "Ivanov", new DateTime(1990, 12, 31), Human.SexT.Male);
            Group g1 = new Group(11, 'A', "phys-math");
            Group g2 = new Group(9, 'A', "phys-math");
            Student s1 = new Student("Ivan", "Ivanovich", "Ivanov", new DateTime(1990, 12, 31), Human.SexT.Male, g1);
            Student s2 = new Student(h, g2);
            //Console.WriteLine(h);
            //Console.WriteLine(g1);
            //Console.WriteLine(s1);

            DataManager dm = new DataManager();
            dm.addStudent(s1);
            dm.addStudent(s2);
            dm.printAllStudents();
        }
    }
}
