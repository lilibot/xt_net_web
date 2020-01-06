using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4NumberValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex commonNotation = new Regex(@"^(-|\+)?\d+(\.\d+)?$");
            Regex scienceNotation = new Regex(@"^(-|\+)?\d+\.\d+(e(-|\+)?|×10(⁻)?)(\d+|[⁰-⁹]*)$");
            Console.WriteLine("Введите число:");
            string text = Console.ReadLine();
            //text = "5.75×10⁹";
            if (commonNotation.IsMatch(text))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else if (scienceNotation.IsMatch(text))
            {
                Console.WriteLine("Это число в научной нотации");
            }
            else
            {
                Console.WriteLine("Это не число");
            }
            Console.ReadKey();
        }
    }
}
