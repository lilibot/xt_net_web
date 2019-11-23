using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3AnotherTriangle
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
            StringBuilder stars = new StringBuilder("*");
            for (var i = 0; i < count; i++)
            {
                for (var s = 0; s < count - i - 1; s++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(stars);
                stars.Append("**");
            }
            Console.ReadKey();
        }
    }
}
