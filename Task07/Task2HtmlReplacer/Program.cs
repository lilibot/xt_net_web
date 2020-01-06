using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2HtmlReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для замены тегов HTML на _:");
            string text = Console.ReadLine();
            Regex htmlRegex = new Regex(@"<.*?>");
            string textWithoutTegs =htmlRegex.Replace(text,"_");
            Console.WriteLine("Текст без тегов:");
            Console.WriteLine(textWithoutTegs);
            Console.ReadKey();
        }
    }
}
