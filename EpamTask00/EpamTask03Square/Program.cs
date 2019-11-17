using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03Square
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawSquare(5);
            Console.ReadKey();
        }
        //displays a square of stars, with a space in the center
        static void DrawSquare(int N)
        {
            if ((N <= 0) || (N % 2 == 0))
            {
                throw new ArgumentException("Argument value should be odd and more than 0");
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == N / 2 && j == N / 2)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }


        }
    }
}
