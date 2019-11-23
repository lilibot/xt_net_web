using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_4X_MasTree
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
            for (int i = 0; i <= count; i++)
            { DisplayTriangle(count, i); }
            Console.ReadKey();
        }
        public static void DisplayTriangle(int countOfTraingles, int countStrsInTriangle)
        {
            int spaces = countOfTraingles - countStrsInTriangle;//spaces depending on the triangle number
            StringBuilder stars = new StringBuilder("*");
            for (var i = 1; i <= countStrsInTriangle; i++)
            {
                for (var s = 0; s < countStrsInTriangle - i +spaces; s++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(stars);
                stars.Append("**");
            }
        }
    }
}
