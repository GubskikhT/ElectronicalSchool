using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool
{
    public class Teacher : Human
    {

        List<Subject> teachedSubjects;

        public Teacher(string name, string secondName, string surname, DateTime birthDay, SexT sex, List<Subject> subjects) : base(name, secondName, surname, birthDay, sex)
        {
            this.teachedSubjects = subjects;
        }

        public List<Subject> TeachedSubjects
        {
            get
            {
                return teachedSubjects;
            }
        }
    }
}
