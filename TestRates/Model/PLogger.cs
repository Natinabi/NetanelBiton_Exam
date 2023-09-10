using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestRating.Interfaces;

namespace TestRating.Model
{
    public class PLogger : IPLogger
    {
        private string logFilePath;

        public PLogger()
        {
            logFilePath = "log.txt";
        }

        public void LogError(string message)
        {
            Log(LogLevel.ERROR, message);
        }

        public void LogInformation(string message)
        {
            Log(LogLevel.INFO, message);
        }

        public void LogWarning(string message)
        {
            Log(LogLevel.WARNING, message);
        }
        private void Log(LogLevel logLevel, string message)
        {
            string logTxt = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] - {message}";

            try
            {
                File.AppendAllText(logFilePath, logTxt + Environment.NewLine);
            }
            catch (Exception ex)
            {
                //should check access or log file
            }

            Console.WriteLine(logTxt);
        }
    }
}
