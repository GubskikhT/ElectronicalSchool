using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    public class Group
    {
        private int level;
        private char label;
        private string description;

        public Group(int level, char label, string description)
        {
            this.level = level;
            this.label = label;
            this.description = description;
        }

        public Group()
        {
        }

        public int Level
        {
            get
            {
                return level;
            }
        }

        public char Label
        {
            get
            {
                return label;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public override string ToString()
        {
            return Level.ToString() + Label.ToString() + " (" + Description + ")";
        }
    }
}
