using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3User
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var users = new List<User>
                { new User("Иванова", "Мария"),
                new User("Юрова","Олеся",new DateTime(1988, 4, 5)),
                new User("Иванов", "Андрей", "Петрович", new DateTime(2001, 1, 2))
                };
                foreach (User user in users)
                {
                    user.PrintInfo();
                    Console.WriteLine();
                }
                new User("Иванов", "Андрей", "Петрович", new DateTime(2030, 1, 2));
                Console.ReadKey();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
