using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            while (true)
            {
                Console.Write("Введите количество строк для вывода треугальника: ");
                if (int.TryParse(Console.ReadLine(), out count) && (count > 0))
                {
                    break;
                }
                else Console.WriteLine("Введенное значение отличается от положительного целого числа!");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            for (var i=new StringBuilder("*");i.Length<=count;i.Append("*"))
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
