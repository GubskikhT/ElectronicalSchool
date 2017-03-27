using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool
{
    public class LoginEventArgs
    {
        public LoginEventArgs(bool auth, int id = -1)
        {
            Auth = auth;
            Id = id;
        }

        public bool Auth { get; private set; }

        public int Id { get; private set; }
    }
}
