using ElectronicJournal.data;
using System;
using System.Runtime.Serialization;

namespace ElectronicSchool
{
    [DataContract]
    public struct JournalEntry
    {
        [DataMember]
        public DateTime Time { get; private set; }
        [DataMember]
        public int StudentId { get; private set; }
        [DataMember]
        public int TeacherId { get; private set; }
        [DataMember]
        public Subject Subject { get; private set; }
        [DataMember]
        public Mark Mark { get; private set; }

        public JournalEntry(DateTime time, int studentId, int teacherId, Subject subject, Mark mark)
        {
            this.Time = time;
            this.StudentId = studentId;
            this.TeacherId = teacherId;
            this.Subject = subject;
            this.Mark = mark;
        }

        public override string ToString()
        {
            var Student = DataManager.DStorage.Id_Login_Map[StudentId];
            var Teacher = DataManager.DStorage.Id_Login_Map[TeacherId];
            return Time + ": " + Student + " " + Teacher +" (" + Subject +") - " + Mark;
        }
    }
}
