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

        public Journal Journal { get; private set; } = new Journal();

        public void MockFill()
        {
            Person h = new Person("admin", "admin", "admin", DateTime.Now, Person.SexT.Male);
            Id_Person_Map.Add(h.Id, h);
            Id_Position_Map.Add(h.Id, Position.Administrator);
            Login_Password_Map.Add("admin", "admin");
            Login_Id_Map.Add("admin", h.Id);
            Id_Login_Map.Add(h.Id, "admin");
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
                    Logger.Info("Removing user succeeded.");
                }
                catch
                {
                    Logger.Warn("Removing user failed.");
                }
            }
        }
    }
}

