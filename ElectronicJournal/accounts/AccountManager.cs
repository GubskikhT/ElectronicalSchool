using ElectronicJournal.data;
using ElectronicJournal.logging;
using ElectronicSchool.accounts;

namespace ElectronicSchool
{
    public static class AccountManager
    {
        private static DataStorage dStorage = DataManager.DStorage;

        public static bool Authenticate(LoginCredentionals credits, out int userId)
        {
            Logger.Info("Authenticating user [" + credits.Username + "]...");
            string storedPassword;
            if (!dStorage.Login_Password_Map.TryGetValue(credits.Username, out storedPassword) || !storedPassword.Equals(credits.Password))
            {
                Logger.Warn("Authentication error. Login and password do not match!");
                userId = -1;
                return false;
            } else
            {
                try
                {
                    dStorage.Login_Id_Map.TryGetValue(credits.Username, out userId);
                    Logger.Info("Authentication succeeded.");
                } catch
                {
                    userId = -1;
                    Logger.Error("Authentication failed.");
                }
                return true;
            }
        }

    }
}
