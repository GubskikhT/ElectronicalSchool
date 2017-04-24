﻿using ElectronicJournal.logging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ElectronicSchool
{
    [DataContract]
    public class Journal
    {
        [DataMember]
        List<JournalEntry> entries = new List<JournalEntry>();

        public void AddEntry(JournalEntry entry)
        {
            Logger.Info("Adding new entry [" + entry + "] to journal...");
            if (IsValid(entry))
            {
                entries.Add(entry);
                Logger.Info("Adding new entry suceeded.");
            } else
            {
                Logger.Warn("Entry is not valid. Adding failed.");
            }
        }

        public List<JournalEntry> GetEntries(int studentId, Subject? subject = null)
        {
            return entries.Where(e => e.StudentId == studentId).Where(e => !subject.HasValue || e.Subject == subject.Value).ToList();
        }

        public bool IsValid(JournalEntry entry)
        {
            //if (!entry.Teacher.TeachedSubjects.Contains(entry.Subject))
            //    return false;
            //// ???
            return true;
        }
    }
}
