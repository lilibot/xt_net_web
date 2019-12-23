using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Xml;

namespace Task1BackupSystem
{
    static class Loger
    {
        private static FileSystemWatcher fileWatcher;
        public static string WatchingDir = @".\FolderForWatching";
        private static string logFilePath = @".\log\log.txt";
        public static string LogPath = @".\log\";
        public static string DateTimeFormat = "yyyy.MM.dd HH.mm.ss";


        public static void BeginToWatch()
        {
            FileWatcher();
            Console.WriteLine("0 - Back");
            while (Console.Read() != '0')
            {
                continue;
            }
            if (Console.Read() != '0')
            {
                Unsubscribe();
            }
        }
        private static void FileWatcher()
        {
            fileWatcher = new FileSystemWatcher(WatchingDir);
            fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            fileWatcher.Changed += OnChanged;
            fileWatcher.Created += OnCreated;
            fileWatcher.Deleted += OnDeleted;
            fileWatcher.Renamed += OnRenamed;

            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.InternalBufferSize = 1024 * 1024;
        }
        private static void Unsubscribe()
        {

            fileWatcher.Changed -= OnChanged;
            fileWatcher.Created -= OnCreated;
            fileWatcher.Deleted -= OnDeleted;
            fileWatcher.Renamed -= OnRenamed;

        }
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            var type = GetType(e.FullPath);
            if (type != ElementType.unknown)
            {
                LogEventInfo(sender, e, type);
            }
        }
        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            string[] temp = e.Name.Split('.');
            string ext = "";
            if (temp.Length>0)
            {
                ext=temp[temp.Length - 1];
            }
            if (ext == "txt")
            {
                LogEventInfo(sender, e, ElementType.file);
            }
            else
            {
                LogEventInfo(sender, e, ElementType.dir);
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            var type = GetType(e.FullPath);
            if (type == ElementType.file)
            {
                string pathWithDate = GetPathWithDate(LogPath, DateTime.Now, e.Name);
                LogEventInfo(sender, e, type, pathWithDate);
                if (!File.Exists(LogPath))
                {

                    File.Copy(e.FullPath, pathWithDate);
                }
            }
        }
        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            var type = GetType(e.FullPath);
            if (type != ElementType.unknown)
            {
                LogOnRenamedInfo(sender, e, type);
            }
        }
        private static ElementType GetType(string path)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                return ElementType.dir;
            else if (new FileInfo(path).Extension == ".txt")
                return ElementType.file;
            else return ElementType.unknown;
        }

        public static void LogOnRenamedInfo(object sender, RenamedEventArgs e, ElementType typeOfObject)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                var now = DateTime.Now;
                writer.WriteLine($"{DateFormat(DateTime.Now)}|{typeOfObject}|{e.OldFullPath}|{e.ChangeType}|{e.FullPath}");
            }
        }

        public static void LogEventInfo(object sender, FileSystemEventArgs e, ElementType typeOfObject, string logTextPath = "")
        {

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    writer.WriteLine($"{DateFormat(DateTime.Now)}|{typeOfObject}|{e.FullPath}|{e.ChangeType}|{logTextPath}");
                }
                else
                    writer.WriteLine($"{DateFormat(DateTime.Now)}|{typeOfObject}|{e.FullPath}|{e.ChangeType}");
            }
        }
        public static string DateFormat(DateTime item)
        {
            return item.ToString(DateTimeFormat);
        }
        public enum ElementType
        {
            unknown = 0,
            file = 1,
            dir = 2
        }
        private static string GetPathWithDate(string str, DateTime dt, string fileName)
        {
            string date = DateFormat(dt);
            string[] strArr = str.Split('\\');
            for (int i = 2; i < strArr.Length; i++)
            {
                strArr[i] = $"${date}${strArr[i]}";
            }
            string[] name = fileName.Split('\\');
            return string.Join("\\", strArr) + name[name.Length - 1];
        }

        public static List<LogerEntry> ReadLog(DateTime dateAndTime)
        {
            List<LogerEntry> logItems = new List<LogerEntry>();
            using (StreamReader logFile = new StreamReader(logFilePath))
            {
                string line;
                while ((line = logFile.ReadLine()) != null)
                {
                    try
                    {
                        var logitem = LogerEntry.ParseLog(line);

                        if (logitem.ChangeDate > dateAndTime)
                        {
                            continue;
                        }
                        else
                        {
                            logItems.Add(logitem);
                        }

                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            logItems.OrderBy(x => x.ChangeDate);
            return logItems;
        }

    }
}
