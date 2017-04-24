using ElectronicJournal.data;
using System;
using System.Runtime.Serialization;

namespace ElectronicSchool
{
    [DataContract]
    public class Person
    {
        public enum SexT { Male, Female}
        
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string SecondName { get; private set; }
        [DataMember]
        public string Surname { get; private set; }
        [DataMember]
        public DateTime BirthDay { get; private set; }
        [DataMember]
        public SexT Sex { get; private set; }

        public Person(string name, string secondName, string surname, DateTime birthDay, SexT sex)
        {
            this.Id = DataManager.DStorage.NextId();
            this.Name = name;
            this.SecondName = secondName;
            this.Surname = surname;
            this.BirthDay = birthDay;
            this.Sex = sex;
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + SecondName + " (" + Sex + ", " + BirthDay.ToShortDateString() + ")";
        }

        public string ToShortString()
        {
            return Surname + " " + Name[0] + ". " + SecondName[0] + ".";
        }
            
    }
}
