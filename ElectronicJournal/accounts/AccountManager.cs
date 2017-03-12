using ElectronicJournal.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    public class AccountManager
    {
        private DataStorage dStorage;

        public AccountManager(DataStorage dStorage)
        {
            this.dStorage = dStorage;
        }

        public bool Login(string username, string password, out int userId)
        {
            string storedPassword;
            if (!dStorage.LoginPasswordDict.TryGetValue(username, out storedPassword) || !storedPassword.Equals(password))
            {
                userId = -1;
                Console.WriteLine("Authentication error!");
                return false;
            } else
            {
                dStorage.LoginIdDict.TryGetValue(username, out userId);
                return true;
            }
        }

        public void RegisterNewUser(string currentUserName, string currentPassword,
            string newUserName, string newPassword, AccountType accountType, Human h)
        {
            int id;
            if (Login(currentUserName, currentPassword, out id))
            {
                AccountType t;
                if (dStorage.IdAccountDict.TryGetValue(id, out t) && t == AccountType.Admin)
                {
                    Console.WriteLine("Registing new user");
                    dStorage.IdAccountDict.Add(h.Id, accountType);
                    dStorage.IdHumanDict.Add(h.Id, h);
                    dStorage.LoginIdDict.Add(newUserName, h.Id);
                    dStorage.LoginPasswordDict.Add(newUserName, newPassword);
                } else
                {
                    Console.WriteLine("Not enought purmishens for registing new user");
                }
            }
        }
    }
}
