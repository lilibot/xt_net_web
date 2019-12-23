using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1BackupSystem
{
    class Backup
    {
        public static void Start(DateTime dateAndTime, string sourceDirName)
        {
            ClearTrackingFolder(Loger.WatchingDir);
            List<LogerEntry> logItems = Loger.ReadLog(dateAndTime);

            try
            {
                foreach (var item in logItems)
                {
                    switch (item.ChangeType)
                    {
                        case WatcherChangeTypes.Changed:
                            {
                                File.Copy(item.OldOrLogPath, item.FileName, true);
                                break;
                            }

                        case WatcherChangeTypes.Created:
                            {
                                if (item.ElementType == Loger.ElementType.file)
                                {
                                    var stream = File.Create(item.FileName);
                                    stream.Close();
                                    break;
                                }
                                else if (item.ElementType == Loger.ElementType.dir)
                                {
                                    Directory.CreateDirectory(item.FileName);
                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException();
                                }
                            }

                        case WatcherChangeTypes.Deleted:
                            {
                                if (item.ElementType == Loger.ElementType.file)
                                {
                                    File.Delete(item.FileName);
                                    break;
                                }
                                else if (item.ElementType == Loger.ElementType.dir)
                                {
                                    Directory.Delete(item.FileName, true);
                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException();
                                }
                            }

                        case WatcherChangeTypes.Renamed:
                            {
                                if (item.ElementType == Loger.ElementType.file)
                                {
                                    File.Move(item.OldOrLogPath, item.FileName);
                                    break;
                                }
                                else if (item.ElementType == Loger.ElementType.dir)
                                {
                                    Directory.Move(item.OldOrLogPath, item.FileName);
                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException();
                                }
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void ClearTrackingFolder(string trackingFolderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(trackingFolderPath);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }

            DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
            foreach (DirectoryInfo subdir in dirInfos)
            {
                Directory.Delete(subdir.FullName, true);
            }
        }
    }
}
