using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{

    public struct Subject
    {
        private string name;
        private int hours;
        private MarkType type;

        public Subject(string name, int hours, MarkType type)
        {
            this.name = name;
            this.hours = hours;
            this.type = type;
        }

        public string Name
        {
            get { return name; }
        }

        public int Hours
        {
            get { return hours; }
        }

        public MarkType MarkType
        {
            get { return type; }
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Subject))
                return false;
            Subject o = (Subject)obj;
            return name == o.name && hours == o.hours && type == o.type;
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
