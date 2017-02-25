using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    public class Student : Human
    {
        private Group group;

        public Student(string name, string secondName, string surname, DateTime birthDay, SexT sex, Group group) : base(name, secondName, surname, birthDay, sex)
        {
            this.group = group;
        }

        public Student(Human h, Group group) : base(h)
        {
            this.group = group;
        }

        public Group Group
        {
            get
            {
                return group;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " [" + group + "]";
        }
    }
}
