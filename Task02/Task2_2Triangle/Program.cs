using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Triangle triangle = new Triangle(2,4,4);
                triangle.WriteInfo();
                Console.WriteLine();
                triangle.B = 5;
                triangle.WriteInfo();
                Console.WriteLine();
                triangle.B = 7;
                Console.ReadKey();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
