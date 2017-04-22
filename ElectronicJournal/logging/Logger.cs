using System;
using System.Diagnostics;
using System.Globalization;

namespace ElectronicJournal.logging
{
    public static class Logger
    {
        private static string logFileName;
        private static string logFileFullPath;

        static Logger()
        {
            StartNewLog();
        }

        private static string TimeStamp()
        {
            return DateTime.UtcNow.ToString("yyyy_MM_dd.HH_mm_ss_fff", CultureInfo.InvariantCulture);
        }

        public static void StartNewLog()
        {
            logFileName = "log_" + TimeStamp() + ".log";
            logFileFullPath = AppConfiguration.LogFolder + "\\" + logFileName;
            System.IO.Directory.CreateDirectory(AppConfiguration.LogFolder);
        }

        private static void Log(string message, char level)
        {
            var senderName = new StackFrame(2).GetMethod().DeclaringType.ToString();
            var msg = level + " " + TimeStamp() + " " + senderName + ": " + message + "\n";
            System.IO.File.AppendAllText(logFileFullPath, msg);
        }

        public static void Debug(string message)
        {
            Log(message, 'D');
        }

        public static void Info(string message)
        {
            Log(message, 'I');
        }

        public static void Warn(string message)
        {
            Log(message, 'W');
        }

        public static void Error(string message)
        {
            Log(message, 'E');
        }
    }
}
