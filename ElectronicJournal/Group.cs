using System;
namespace ElectronicSchool
{
    public class Group
    {
        public int Level { get; private set; }
        public char Label { get;  private set; }
        public string Description { get; private set; }

        public Group(int level, char label, string description)
        {
            this.Level = level;
            this.Label = label;
            this.Description = description;
        }

        public Group()
        {
        }

        public override string ToString()
        {
            return Level.ToString() + Label.ToString() + " (" + Description + ")";
        }
    }
}
