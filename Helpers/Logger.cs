using System;
using System.IO;

namespace Mars.Helpers
{
    public static class Logger
    {
        private static string logDirectoryPath = "Logs";  // Logs folder path
        private static string logFilePath = Path.Combine(logDirectoryPath, "TestLog.txt");  // Log file path

        // Initialize log file
        public static void InitializeLogFile()
        {
            if (!Directory.Exists(logDirectoryPath))
            {
                Directory.CreateDirectory(logDirectoryPath);
            }

            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);  // Clear log file before each run
            }

            using (StreamWriter sw = File.CreateText(logFilePath))
            {
                sw.WriteLine("Test Log - MARS Portal Automation");
                sw.WriteLine("================================");
            }
        }

        // Write log messages to both the log file and the console
        public static void Log(string message)
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }

            Console.WriteLine(message);  // Print to console as well
        }
    }
}