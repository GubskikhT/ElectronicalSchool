using ElectronicJournal.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ElectronicJournal
{
    [DataContract]
    public class DataStorage
    {
        [DataMember]
        private Dictionary<int, Human> idHumanDict = new Dictionary<int, Human>();
        [DataMember]
        private Dictionary<int, AccountType> idAccountDict = new Dictionary<int, AccountType>();
        [DataMember]
        private Dictionary<string, string> loginPasswordDict = new Dictionary<string, string>();
        [DataMember]
        private Dictionary<string, int> loginIdDict = new Dictionary<string, int>();

        private Journal journal = new Journal();

        public DataStorage()
        {
            Human h = new Human("admin", "admin", "admin", DateTime.Now, Human.SexT.Male);
            idHumanDict.Add(h.Id, h);
            idAccountDict.Add(h.Id, AccountType.Admin);
            loginPasswordDict.Add("admin", "admin");
            loginIdDict.Add("admin", h.Id);
        }

        public Journal Journal
        {
            get
            {
                return journal;
            }
        }

        public Dictionary<string, int> LoginIdDict
        {
            get { return loginIdDict; }
        }

        public Dictionary<int, Human> IdHumanDict
        {
            get { return idHumanDict; }
        }

        public Dictionary<int, AccountType> IdAccountDict
        {
            get { return idAccountDict; }
        }

        public Dictionary<string, string> LoginPasswordDict
        {
            get { return loginPasswordDict; }
        }

        public void printAllStudents()
        {
            IdHumanDict.Values
                .Where(x => x.GetType() == typeof(Student)).ToList()
                .ForEach(s => Console.WriteLine(s));
        }
    }
}
