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
            DataStorage ds = new DataStorage();
            AccountManager am = new AccountManager(ds);
            Human hh = new Human("1", "2", "3", DateTime.Now, Human.SexT.Female);
            am.RegisterNewUser("admin", "admin", "user1", "", accounts.AccountType.Common, hh);
            var serializer = new Serializator();
            serializer.SerializeStorage(ds);


            Human h = new Human("Ivan", "Ivanovich", "Ivanov", new DateTime(1990, 12, 31), Human.SexT.Male);
            Group g1 = new Group(11, 'A', "phys-math");
            Group g2 = new Group(9, 'A', "phys-math");
            Student s1 = new Student("Ivan", "Ivanovich", "Ivanov", new DateTime(1990, 12, 31), Human.SexT.Male, g1);
            Student s2 = new Student(h, g2);
            //Console.WriteLine(h);
            //Console.WriteLine(g1);
            //Console.WriteLine(s1);

            //DataStorage dm = new DataStorage();
            //dm.addStudent(s1);
            //dm.addStudent(s2);
            //dm.printAllStudents();

            //Subject sub1 = new Subject("programming", 36, MarkType.Scored);
            //Subject sub2 = new Subject("maths", 48, MarkType.Scored);
            //Subject sub3 = new Subject("philosophy", 24, MarkType.Binary);
            //dm.Subjects.Add(sub1);

            //Teacher t1 = new Teacher("Artemey", "Ivanovich", "Sobolev", new DateTime(1990, 3, 15), Human.SexT.Male, new List<Subject>{sub1, sub2});
            //Teacher t2 = new Teacher("Galina", "Fedorovna", "Kuzmina", new DateTime(1955, 3, 25), Human.SexT.Female, new List<Subject>{sub3});
            ////dm.Teachers.Add(t1);
            //dm.Journal.AddEntry(t1, sub1, DateTime.Now, s1, new Mark(MarkType.Scored, 5));
            //dm.Journal.AddEntry(t1, sub1, DateTime.Now, s2, new Mark(MarkType.Scored, 4));
            //dm.Journal.AddEntry(t1, sub2, DateTime.Now, s1, new Mark(MarkType.Scored, 3));
            //dm.Journal.AddEntry(t1, sub2, DateTime.Now, s2, new Mark(MarkType.Scored, 3));
            //dm.Journal.AddEntry(t1, sub3, DateTime.Now, s1, new Mark(MarkType.Scored, 5));
            //dm.Journal.AddEntry(t2, sub3, DateTime.Now, s2, new Mark(MarkType.Scored, 2));

            //dm.Journal.GetEntries(s1).ForEach(e => Console.WriteLine(e));

        }
    }
}
