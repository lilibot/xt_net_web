using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_5Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var employees = new List<Employee>
                { new Employee("Иванова", "Мария"),
                new Employee("Юрова","Олеся",new DateTime(1988, 4, 5)),
                new Employee("Иванов", "Андрей", "Петрович", new DateTime(2001, 1, 2))
                };
                employees[0].Position = "Manager";
                employees[0].WorkExperience = 6;
                employees[2].Position = "Accountant";
                employees[2].WorkExperience = 2;
                foreach (Employee user in employees)
                {
                    user.PrintInfo();
                    Console.WriteLine();
                }
                var e=new Employee("Иванов", "Андрей", "Петрович", new DateTime(2010, 1, 2));
                //e.WorkExperience = -2;
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
