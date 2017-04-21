namespace ElectronicSchool.accounts
{
    public struct LoginCredentionals
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public LoginCredentionals(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
