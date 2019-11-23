using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            int length;
            while (true)
            {
                Console.Write("Введите длину прямоугольника: ");
                if (int.TryParse(Console.ReadLine(), out length))
                {
                    try
                    {
                        rect.Length = length;
                        break;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            int width;
            while (true)
            {
                Console.Write("Введите ширину прямоугольника: ");
                if (int.TryParse(Console.ReadLine(), out width))
                {
                    try
                    {
                        rect.Width = width;
                        break;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }

            Console.WriteLine(rect.CalculateArea().ToString());
            Console.ReadKey();
        }
    }
}
