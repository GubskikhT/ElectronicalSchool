using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    public class Journal
    {
        List<JournalEntry> entries = new List<JournalEntry>();


        public void AddEntry(Teacher teacher, Subject subject, DateTime time, Student student, Mark mark)
        {
            var entry = new JournalEntry(time, student, teacher, subject, mark);
            if (IsValid(entry))
            {
                entries.Add(entry);
            } else
            {
                Console.Error.WriteLine("Trying to add the invalid entry");
            }
        }

        public List<JournalEntry> GetEntries(Student student, Subject? subject = null)
        {
            return entries.Where(e => e.Student == student).Where(e => !subject.HasValue || (subject.HasValue && e.Subject == subject.Value)).ToList();
        }

        public bool IsValid(JournalEntry entry)
        {
            if (!entry.Teacher.TeachedSubjects.Contains(entry.Subject))
                return false;
            // ???
            return true;
        }
    }
}
