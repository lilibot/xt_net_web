using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_10_2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Исходный массив: ");
            int[,] array = new int[3, 3];
            Random rand = new Random();
            int sumOfElementsAtEvenPositions = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = rand.Next(-10, 10);
                    Console.Write($"{array[i, j]}, ");
                    if (((i + j) % 2 == 0)&&((i != 0)||(j != 0))) sumOfElementsAtEvenPositions += array[i, j];
                }
                Console.WriteLine();
            }
            Console.Write($"Сумма элементов на четных позициях: {sumOfElementsAtEvenPositions}");
            Console.ReadKey();

        }
    }
}
