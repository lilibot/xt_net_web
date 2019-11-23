using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_12CharDoubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string str1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string str2 = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (char ch in str1)
            {
                if (str2.Contains(ch))
                {
                    sb.Append(ch);
                    sb.Append(ch);
                }
                else
                {
                    sb.Append(ch);
                }
            }

            str1 = sb.ToString();
            Console.WriteLine($"Результирующая строка: {str1}");
            Console.ReadKey();
        }
    }
}
