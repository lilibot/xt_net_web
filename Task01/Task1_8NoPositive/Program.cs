using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_8NoPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[5,5,5];
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        array[i, j, k] = rand.Next(-10, 10);
                    }
                }
            }

            Console.WriteLine("Исходные элементы массива: ");
            foreach (var i in array) Console.Write($"{i} ");
            GetNoPositiveArray(array);
            Console.WriteLine("\nЭлементы после замены положительных элементов: ");
            foreach (var i in array) Console.Write($"{i} ");
            Console.ReadKey();
        }
        public static void GetNoPositiveArray(int[,,] array)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if(array[i, j, k]>0)
                        array[i, j, k] = 0;
                    }
                }
            }

        }
    }
}
