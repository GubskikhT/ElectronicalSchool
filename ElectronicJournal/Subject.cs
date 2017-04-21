namespace ElectronicSchool
{

    public struct Subject
    {
        public string Name { get; private set; }
        public int Hours { get; private set; }

        public Subject(string name, int hours)
        {
            this.Name = name;
            this.Hours = hours;
        }

        public override bool Equals(object obj)
        {
            return obj is Subject && this == (Subject)obj;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Hours.GetHashCode();
        }

        public static bool operator ==(Subject s1, Subject s2)
        {
            return s1.Name == s2.Name && s1.Hours == s2.Hours;
        }

        public static bool operator !=(Subject s1, Subject s2)
        {
            return !s1.Equals(s2);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
