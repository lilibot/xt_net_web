using BLL.Interfaces;
using Entities;
using Ioc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePL
{
    class Program
    {
        private static readonly string DateFormat = "dd.MM.yyyy";
        private static IUserLogic _userLogic;
        private static IAwardLogic _awardLogic;
        static void Main(string[] args)
        {
            _userLogic = DependencyResolver.UserLogic;
            _awardLogic = DependencyResolver.AwardLogic;
            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("1. Add user");
                    Console.WriteLine("2. Remove user by id");
                    Console.WriteLine("3. Add user's award dy id");
                    Console.WriteLine("4. Show list of users");
                    Console.WriteLine("5. Show users with awards");
                    Console.WriteLine("6. Add award");
                    Console.WriteLine("7. Remove award by id");
                    Console.WriteLine("8. Show awards");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("--------------------------");

                    ConsoleKeyInfo entry = Console.ReadKey(intercept: true);

                    switch (entry.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                AddUser();
                                Console.WriteLine("User saved.");
                                break;
                            }

                        case ConsoleKey.D2:
                            {
                                RemoveUserById();
                                break;
                            }

                        case ConsoleKey.D3:
                            {
                                AddAwardToUser();
                                break;
                            }

                        case ConsoleKey.D4:
                            {
                                ShowUsers();
                                break;
                            }

                        case ConsoleKey.D5:
                            {
                                ShowUsersWithAwards();
                                break;
                            }

                        case ConsoleKey.D6:
                            {
                                AddAward();
                                Console.WriteLine("Award saved.");
                                break;
                            }

                        case ConsoleKey.D7:
                            {
                                RemoveAwardById();
                                break;
                            }

                        case ConsoleKey.D8:
                            {
                                ShowAwards();
                                break;
                            }

                        case ConsoleKey.D0:
                            {
                                return;
                            }
                    }

                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Error: {e.Message}");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void ShowAwards()
        {
            var awards = _awardLogic.GetAll();
            Console.WriteLine("Awards: ");
            foreach (var award in awards)
            {
                Console.WriteLine(award);
            }
        }

        private static void RemoveAwardById()
        {
            Console.Write("Enter award's id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException("Id must be a number");
            }
            _awardLogic.RemoveById(id);
        }

        private static void AddAward()
        {
            Console.WriteLine("Type title of award: ");
            string nameOfAward = Console.ReadLine();
            if (string.IsNullOrEmpty(nameOfAward))
            {
                throw new ArgumentException("Title can`t be null or empty");
            }
            Award award = new Award { Title = nameOfAward };
            _awardLogic.Add(award);
        }

        private static void ShowUsersWithAwards()
        {
            var users = _userLogic.GetAll();
            Console.WriteLine("Users with awards: ");
            foreach (var user in users)
            {
                Console.WriteLine(user);
                Console.Write("Awards: ");
                foreach (var awardId in user.Awards)
                {
                    Console.WriteLine(_awardLogic.GetById(awardId));
                }
                Console.WriteLine();
            }
        }

        private static void ShowUsers()
        {
            var users = _userLogic.GetAll();
            Console.WriteLine("Users: ");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        private static void AddAwardToUser()
        {
            Console.Write("Enter ID of user: ");

            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                throw new ArgumentException("Id of user must be a number");
            }

            if (_awardLogic.GetAll().Count() == 0)
            {
                Console.WriteLine("Not a single award has been created yet");
                return;
            }

            Console.WriteLine();
            ShowAwards();

            Console.WriteLine();
            Console.WriteLine("Pick one of the Id`s: ");
            if (!int.TryParse(Console.ReadLine(), out int awardId))
            {
                throw new ArgumentException("Id of award must be a number");
            }

            _userLogic.AddAward(userId, awardId);
        }

        private static void RemoveUserById()
        {
            Console.Write("Enter user's id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException("Id must be a number");
            }
            _userLogic.RemoveById(id);
        }

        private static void AddUser()
        {
            User user = EnterUser();
            _userLogic.Add(user);
        }
        private static User EnterUser()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can`t be null or empty");
            }

            Console.Write($"Enter birthday. Format: {DateFormat}. ");
            string birthday = Console.ReadLine();
            DateTime dateTemp;

            if (DateTime.TryParseExact(birthday, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTemp))
            {
                return new User { Name = name, DateOfBirth = dateTemp };
            }
            else
            {
                throw new ArgumentException("Incorrect date");
            }
        }
    }
}
