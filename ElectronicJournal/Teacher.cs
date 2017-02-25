using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    class Teacher : Human
    {
        public Teacher(string name, string secondName, string surname, DateTime birthDay, SexT sex) : base(name, secondName, surname, birthDay, sex)
        {
        }
    }
}
