using ElectronicSchool;

namespace ElectronicJournal
{
    public class ExtendedPerson
    {
        public Person Person { get; private set; }
        public Position Position { get; private set; }

        public ExtendedPerson(Person p, Position pos)
        {
            Person = p;
            Position = pos;
        }

        public override string ToString()
        {
            return Position.ToString() + ": " + Person.ToShortString();
        }
    }
}
