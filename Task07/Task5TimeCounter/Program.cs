using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task5TimeCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для подсчета количества времени:");
            string text = Console.ReadLine();
            Regex timeRegex = new Regex(@"\b(([0-1]\d|2[0-3])|\d)(:[0-5]\d)\b");
            MatchCollection timeFromText = timeRegex.Matches(text);
            Console.WriteLine($"Время в тексте присутствует {timeFromText.Count} раз.");
            Console.ReadKey();
        }
    }
}
