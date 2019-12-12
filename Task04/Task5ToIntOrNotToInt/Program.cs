using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5ToIntOrNotToInt
{
    static class Program
    {
        static void Main(string[] args)
        {
            string str1 = "00056";
            string str2 = "-56";
            string str3 = "h";
            string str4 = "1000000";
            Console.WriteLine($"{str1}: {str1.IsPositiveNumber()}");
            Console.WriteLine($"{str2}: {str2.IsPositiveNumber()}");
            Console.WriteLine($"{str3}: {str3.IsPositiveNumber()}");
            Console.WriteLine($"{str4}: {str4.IsPositiveNumber()}");
            Console.ReadKey();
        }
        public static bool IsPositiveNumber(this string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str[i]))
                {
                    return false;
                }
            }

            return true;
        }


    }
}
