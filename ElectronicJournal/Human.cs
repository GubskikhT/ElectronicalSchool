using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    public class Human
    {
        public enum SexT { Male, Female}

        private string name;
        private string secondName;
        private string surname;
        private DateTime birthDay;
        private SexT sex;

        public Human(string name, string secondName, string surname, DateTime birthDay, SexT sex)
        {
            this.name = name;
            this.secondName = secondName;
            this.surname = surname;
            this.birthDay = birthDay;
            this.sex = sex;
        }

        public Human(Human h)
        {
            this.name = h.Name;
            this.secondName = h.SecondName;
            this.surname = h.Surname;
            this.birthDay = h.BirthDay;
            this.sex = h.Sex;
        }

        public string Name
        {
            get { return name; }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
        }

        public DateTime BirthDay
        {
            get
            {
                return birthDay;
            }
        }

        private SexT Sex
        {
            get
            {
                return sex;
            }
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + SecondName + " (" + Sex + ", " + BirthDay.ToShortDateString() + ")";
        } 
            
    }
}
