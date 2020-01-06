using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3EmailFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст с адресами электронной почты:");
            string text = Console.ReadLine();
            Regex emailRegex = new Regex(@"([^\W_]([\w-\.]*)[^\W_]|([^\W_]))@([^\W_]+\.)+[^\W\d]{2,6}");
            MatchCollection emails = emailRegex.Matches(text);
            Console.WriteLine("Найденные адреса электронной почты:");
            foreach (Match email in emails)
            {
                Console.WriteLine(email.Value);
            }
            Console.ReadKey();
        }
    }
}
