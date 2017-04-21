using System;
using System.Runtime.Serialization;

namespace ElectronicSchool
{
    [DataContract]
    public class Human
    {
        public enum SexT { Male, Female}

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

        public Human(string name, string secondName, string surname, DateTime birthDay, SexT sex)
        {
            this.Id = IdGenerator.GenerateId();
            this.Name = name;
            this.SecondName = secondName;
            this.Surname = surname;
            this.BirthDay = birthDay;
            this.Sex = sex;
        }

        public Human(Human h)
        {
            this.Name = h.Name;
            this.SecondName = h.SecondName;
            this.Surname = h.Surname;
            this.BirthDay = h.BirthDay;
            this.Sex = h.Sex;
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + SecondName + " (" + Sex + ", " + BirthDay.ToShortDateString() + ")";
        } 
            
    }
}
