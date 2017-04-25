using ElectronicSchool.accounts;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ElectronicJournal;
using System;
using ElectronicJournal.logging;

namespace ElectronicSchool
{
    [DataContract]
    public class DataStorage
    {
        [DataMember]
        private int lastId = 0;

        [DataMember]
        public Dictionary<int, Person> Id_Person_Map { get; private set; } = new Dictionary<int, Person>();

        [DataMember]
        public Dictionary<int, Position> Id_Position_Map { get; private set; } = new Dictionary<int, Position>();

        [DataMember]
        public Dictionary<int, Subject> Id_Subject_Map { get; private set; } = new Dictionary<int, Subject>();

        [DataMember]
        public Dictionary<string, string> Login_Password_Map { get; private set; } = new Dictionary<string, string>();

        [DataMember]
        public Dictionary<string, int> Login_Id_Map { get; private set; } = new Dictionary<string, int>();

        [DataMember]
        public Dictionary<int, string> Id_Login_Map { get; private set; } = new Dictionary<int, string>();

        [DataMember]
        public Dictionary<int, int> Guest_Studednt_Map { get; private set; } = new Dictionary<int, int>();

        [DataMember]
        public Journal Journal { get; private set; } = new Journal();

        public void MockFill()
        {
            Person h1 = new Person("admin", "admin", "admin", new DateTime(1990, 11, 3), Person.SexT.Male);
            Id_Person_Map.Add(h1.Id, h1);
            Id_Position_Map.Add(h1.Id, Position.Administrator);
            Login_Password_Map.Add("admin", "admin");
            Login_Id_Map.Add("admin", h1.Id);
            Id_Login_Map.Add(h1.Id, "admin");

            Person h2 = new Person("Anrey", "Andreevich", "Tikhonov", new DateTime(1970, 10, 5), Person.SexT.Male);
            Id_Person_Map.Add(h2.Id, h2);
            Id_Position_Map.Add(h2.Id, Position.Teacher);
            Login_Password_Map.Add("teacher", "teacher");
            Login_Id_Map.Add("teacher", h2.Id);
            Id_Login_Map.Add(h2.Id, "teacher");
            Id_Subject_Map.Add(h2.Id, Subject.Mathematics);

            Person h3 = new Person("Petr", "Ivanovich", "Sobolev", new DateTime(1998, 2, 2), Person.SexT.Male);
            Id_Person_Map.Add(h3.Id, h3);
            Id_Position_Map.Add(h3.Id, Position.Student);
            Login_Password_Map.Add("student", "student");
            Login_Id_Map.Add("student", h3.Id);
            Id_Login_Map.Add(h3.Id, "student");

            Person h4 = new Person("Anna", "Ivanovna", "Soboleva", new DateTime(1973, 4, 20), Person.SexT.Female);
            Id_Person_Map.Add(h4.Id, h4);
            Id_Position_Map.Add(h4.Id, Position.Guest);
            Login_Password_Map.Add("parent", "parent");
            Login_Id_Map.Add("parent", h4.Id);
            Id_Login_Map.Add(h4.Id, "parent");
            Guest_Studednt_Map.Add(h4.Id, h3.Id);
        }

        public int NextId()
        {
            return ++lastId;
        }

        private bool CheckPermission(LoginCredentionals credits)
        {
            Logger.Info("Cheking permissions...");
            int id;
            Position position;
            if (AccountManager.Authenticate(credits, out id))
            {
                if (Id_Position_Map.TryGetValue(id, out position) && position == Position.Administrator)
                {
                    Logger.Info("Ok.");
                    return true;
                }
                else
                {
                    Logger.Warn("Not enought permitions!");
                }
            }
            else
            {
                Logger.Warn("Current user authentication [" + credits.Username + "] failed.");
            }
            return false;
        }

        public void RegisterNewUser(LoginCredentionals credits, LoginCredentionals newUserCredits, Position position, Person p)
        {
            Logger.Info("Trying to register new user...");
            if (CheckPermission(credits))
            {
                Console.WriteLine("Registing new user [" + p + "][" + position + "...");
                try
                {
                    Id_Position_Map.Add(p.Id, position);
                    Id_Person_Map.Add(p.Id, p);
                    Id_Login_Map.Add(p.Id, newUserCredits.Username);
                    Login_Id_Map.Add(newUserCredits.Username, p.Id);
                    Login_Password_Map.Add(newUserCredits.Username, newUserCredits.Password);
                    Logger.Info("Regestering new user succeeded.");
                }
                catch
                {
                    Logger.Warn("Registering new user failed.");
                }
            }
        }

        public void RegisterTeacher(LoginCredentionals credits, int id, Subject subject)
        {
            Logger.Info("Trying to add a teacher [" + id + "]...");
            if (CheckPermission(credits))
            {
                Console.WriteLine("Adding new teacher...");
                try
                {
                    Id_Subject_Map.Add(id, subject);
                    Logger.Info("Regestering new teacher succeeded.");
                }
                catch
                {
                    Logger.Warn("Registering new teacher failed.");
                }
            }
        }

        public void RegisterGuest(LoginCredentionals credits, int studentId, int guestId)
        {
            Logger.Info("Trying to add a guest [" + guestId + "] to watch student [" + studentId + "]...");
            if (CheckPermission(credits))
            {
                Console.WriteLine("Adding new guest...");
                try
                {
                    Guest_Studednt_Map.Add(guestId, studentId);
                    Logger.Info("Regestering new guest succeeded.");
                }
                catch
                {
                    Logger.Warn("Registering new guest failed.");
                }
            }
        }

        public void RemoveUser(LoginCredentionals credits, int id)
        {
            Logger.Info("Trying to remove a user [" + id + "]...");
            if (CheckPermission(credits))
            {
                try
                {
                    if (Id_Login_Map.ContainsKey(id))
                    {
                        var login = Id_Login_Map[id];
                        if (Login_Id_Map.ContainsKey(login))
                            Login_Id_Map.Remove(login);
                        Id_Login_Map.Remove(id);
                    }
                    if (Id_Person_Map.ContainsKey(id))
                        Id_Person_Map.Remove(id);
                    if (Id_Position_Map.ContainsKey(id))
                        Id_Position_Map.Remove(id);
                    if (Id_Subject_Map.ContainsKey(id))
                        Id_Subject_Map.Remove(id);
                    if (Guest_Studednt_Map.ContainsKey(id))
                        Guest_Studednt_Map.Remove(id);
                    Logger.Info("Removing user succeeded.");
                }
                catch
                {
                    Logger.Warn("Removing user failed.");
                }
            }
        }

        public List<Person> GetStudents()
        {
            List<Person> students = new List<Person>();
            foreach(var i in Id_Position_Map)
                if (i.Value == Position.Student)
                    students.Add(Id_Person_Map[i.Key]);
            return students;
        }
    }
}

