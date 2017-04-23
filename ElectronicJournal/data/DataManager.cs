using ElectronicJournal.logging;
using ElectronicSchool;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ElectronicJournal.data
{
    public static class DataManager
    {
        public static DataStorage DStorage { get; private set; }// = new DataStorage();

        private static string dataFileFullName = AppConfiguration.DataFolder + "data.ser";

        static DataManager() {
            LoadStorage();
        }

        public static void SaveStorage()
        {
            Logger.Info("Saving data to " + dataFileFullName);
            if (!Directory.Exists(AppConfiguration.DataFolder))
            {
                Logger.Error("Error while saving data. The folder does not exist.");
                return;
            }
            if (DStorage == null)
            {
                Logger.Error("Error while saving data. Data is null.");
                return;
            }
            using (var ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DataStorage));
                using (var stream = File.Create(dataFileFullName))
                {
                    ser.WriteObject(stream, DStorage);
                }
            }
            Logger.Info("Saving succeeded.");
        }

        public static void LoadStorage()
        {
            Logger.Info("Loading data from " + dataFileFullName);
            if (!Directory.Exists(AppConfiguration.DataFolder))
            {
                Logger.Error("Error while loading data. The folder does not exist.");
                return;
            }
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DataStorage));
            using (var stream = File.OpenRead(dataFileFullName))
            {
                DStorage = ser.ReadObject(stream) as DataStorage;
            }
            Logger.Info("Loading succeeded.");
        }

    }
}
