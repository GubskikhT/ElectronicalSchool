using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool.accounts
{
    public struct LoginCredentials
    {
        private readonly string username, password;

        public LoginCredentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return username;  }
        }

        public string Password
        {
            get { return password; }
        }
    }
}
