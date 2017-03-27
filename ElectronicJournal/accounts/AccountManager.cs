using ElectronicSchool.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool
{
    public class AccountManager
    {
        private DataStorage dStorage;

        public AccountManager(DataStorage dStorage)
        {
            this.dStorage = dStorage;
        }

        public bool Authenticate(LoginCredentials credits, out int userId)
        {
            string storedPassword;
            if (!dStorage.LoginPasswordDict.TryGetValue(credits.Username, out storedPassword) || !storedPassword.Equals(credits.Password))
            {
                userId = -1;
                Console.WriteLine("Authentication error!");
                return false;
            } else
            {
                dStorage.LoginIdDict.TryGetValue(credits.Username, out userId);
                return true;
            }
        }

        public void RegisterNewUser(LoginCredentials credits,
            string newUserName, string newPassword, AccountType accountType, Human h)
        {
            int id;
            if (Authenticate(credits, out id))
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
