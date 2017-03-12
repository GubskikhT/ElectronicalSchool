using ElectronicJournal.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    [DataContract]
    public class Human
    {
        public enum SexT { Male, Female}

        private int id;
        [DataMember]
        private string name;
        [DataMember]
        private string secondName;
        [DataMember]
        private string surname;
        [DataMember]
        private DateTime birthDay;
        [DataMember]
        private SexT sex;

        public Human(string name, string secondName, string surname, DateTime birthDay, SexT sex)
        {
            this.id = IdGenerator.GenerateId();
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

        public int Id
        {
            get { return id; }
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + SecondName + " (" + Sex + ", " + BirthDay.ToShortDateString() + ")";
        } 
            
    }
}
