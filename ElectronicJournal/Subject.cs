using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool
{

    public struct Subject
    {
        private string name;
        private int hours;

        public Subject(string name, int hours)
        {
            this.name = name;
            this.hours = hours;
        }

        public string Name
        {
            get { return name; }
        }

        public int Hours
        {
            get { return hours; }
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Subject))
                return false;
            Subject o = (Subject)obj;
            return name == o.name && hours == o.hours;
        }

        public static bool operator ==(Subject s1, Subject s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Subject s1, Subject s2)
        {
            return !s1.Equals(s2);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
