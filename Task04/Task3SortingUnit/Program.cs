using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3User;

namespace Task3SortingUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка массива строк по длине строки и алфавиту, если строки равны: ");
            string[] array2 = new string[] { "lalal", "vv", "dddddddddddddddddd", "a", "c", "b", "av", "dd" };
            PrintArray(array2);
            SortingUnit.OnSortIsFinished += OnSortFinishedHandler;
            SortingUnit.SortArrayInNewThread(array2, (s1, s2) =>
            {
                if (s1.Length == s2.Length)
                {
                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                        if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
                    }
                    return false;
                }
                else return s1.Length > s2.Length;
            });
            PrintArray(array2);
            Console.WriteLine("Сортировка массива пользователей по возрасту: ");
            User[] users = new User[] { new User("Иванова", "Мария",new DateTime(1995, 4, 5)),
                new User("Юрова","Олеся",new DateTime(1988, 4, 5)),
                new User("Иванов", "Андрей", "Петрович", new DateTime(2001, 1, 2)) };
            PrintArray(users);
            Console.WriteLine();
            SortingUnit.SortArrayInNewThread(users, (x1, x2) => x1.Age > x2.Age);
            PrintArray(users);
            Console.ReadKey();
        }
        public static void PrintArray<T>(IEnumerable<T> array)
        {
            foreach (var element in array)
            {
                Console.Write(element);
                Console.Write(", ");
            }
            Console.WriteLine();
        }
        public static void OnSortFinishedHandler(string message)
        {
            Console.WriteLine(message);
        }
    }
}
