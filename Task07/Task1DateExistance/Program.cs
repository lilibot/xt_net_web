using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1DateExistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для поиска даты:");
            string text = Console.ReadLine();
            Regex dateRegex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\d\d");
            if (dateRegex.IsMatch(text))
            {
                Console.WriteLine("В тексте содержится дата в формате dd-mm-yyyy"); 
            }
            else
            {
                Console.WriteLine("В тексте нет даты в формате dd-mm-yyyy");
            }
            Console.ReadKey();
        }
    }
}
