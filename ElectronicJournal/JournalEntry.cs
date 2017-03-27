using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool
{
    public struct JournalEntry
    {
        DateTime time;
        Student student;
        Teacher teacher;
        Subject subject;
        Mark mark;

        public JournalEntry(DateTime time, Student student, Teacher teacher, Subject subject, Mark mark)
        {
            this.time = time;
            this.student = student;
            this.teacher = teacher;
            this.subject = subject;
            this.mark = mark;
        }

        public DateTime Time
        {
            get
            {
                return time;
            }
        }

        public Student Student
        {
            get
            {
                return student;
            }
        }

        internal Teacher Teacher
        {
            get
            {
                return teacher;
            }
        }

        internal Subject Subject
        {
            get
            {
                return subject;
            }
        }

        public Mark Mark
        {
            get
            {
                return mark;
            }
        }

        public override string ToString()
        {
            return time + ": " + Student + " " + Teacher +" (" + Subject +") - " + Mark;
        }
    }
}
