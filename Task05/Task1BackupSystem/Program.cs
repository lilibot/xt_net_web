using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1BackupSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int pickedElemMenu;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите режим:");
                Console.WriteLine("1 - Наблюдение");
                Console.WriteLine("2 - Откат изменений");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");

                while (!int.TryParse(Console.ReadLine(), out pickedElemMenu))
                {
                    Console.WriteLine("Incorrect value: valid values are 1 and 2");
                }

                switch (pickedElemMenu)
                {
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }

                    case 1:
                        {
                            Loger.BeginToWatch();
                            break;
                        }

                    case 2:
                        {
                            DateTime dateTime = ReadDateFromConsole();
                            Backup.Start(dateTime, Loger.LogPath);
                            Console.WriteLine("Backup has done!");
                            Console.ReadKey();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Incorrect value: valid values are 0, 1 and 2");
                            break;
                        }
                }

                Console.ReadKey();
            }
        }
        public static DateTime ReadDateFromConsole()
        {
            try
            {
                Console.WriteLine("Please, input date and time:");

                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Month: ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Day: ");
                int day = int.Parse(Console.ReadLine());

                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Minutes: ");
                int mins = int.Parse(Console.ReadLine());

                Console.Write("Seconds (optional): ");
                int seconds = 0;
                int.TryParse(Console.ReadLine(), out seconds);

                return new DateTime(year, month, day, hours, mins, seconds);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.InnerException);
                throw;
            }
        }

    }
}


