using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Task1BackupSystem
{
    class LogerEntry
    {
        public string FileName { get; set; }
        public DateTime ChangeDate { get; set; }
        public WatcherChangeTypes ChangeType { get; set; }
        public string OldOrLogPath { get; set; }
        public Loger.ElementType ElementType { get; set; }
        public LogerEntry(string fileName, DateTime changeDate, WatcherChangeTypes changeType, Loger.ElementType elementType)
        {
            FileName = fileName;
            ChangeDate = changeDate;
            ChangeType = changeType;
            ElementType = elementType;
        }

        public LogerEntry(string fileName, DateTime changeDate, WatcherChangeTypes changeType, Loger.ElementType elementType, string oldOrLogPath)
            : this(fileName, changeDate, changeType, elementType)
        {
            OldOrLogPath = oldOrLogPath;
        }
        public static LogerEntry ParseLog(string line)
        {
            try
            {
                string[] array = line.Split('|');

                string timeOfChanges = array[0];
                string typeOfObject = array[1];
                string typeOfChanges = array[3];

                var elementType = (Loger.ElementType)Enum.Parse(typeof(Loger.ElementType), typeOfObject);
                var date = ParseDate(timeOfChanges);
                switch (array[3])
                {
                    case "Created":
                        {
                            string path = array[2];
                            return new LogerEntry(path, date, WatcherChangeTypes.Created, elementType);
                        }
                    case "Deleted":
                        {
                            string path = array[2];
                            return new LogerEntry(path, date, WatcherChangeTypes.Deleted, elementType);
                        }
                    case "Renamed":
                        {
                            string oldPath = array[2];
                            string newPath = array[4];
                            return new LogerEntry(newPath, date, WatcherChangeTypes.Renamed, elementType, oldPath);
                        }
                    case "Changed":
                        {
                            string path = array[2];
                            string logPath = array[4];
                            return new LogerEntry(path, date, WatcherChangeTypes.Changed, elementType, logPath);
                        }
                    default:
                        throw new ArgumentException("Change type error");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }


        private static DateTime ParseDate(string dateAndTime)
        {
            try
            {
                DateTime newDate = DateTime.ParseExact(dateAndTime, Loger.DateTimeFormat, CultureInfo.CurrentCulture);
                return newDate;
            }
            catch
            {
                throw new ArgumentException("DateParse error");
            }
        }
    }
}
