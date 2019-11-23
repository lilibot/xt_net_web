using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_9Non_NegativeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                array[i] = rand.Next(-100, 100);
            }
            Console.WriteLine("Исходный массив: ");
            foreach (var i in array) Console.Write($"{i} ");
            Console.WriteLine($"\nСумма неотрицательных элементов в массиве: {SumOfPositiveElements(array)}");
            Console.ReadKey();
        }
        public static int SumOfPositiveElements(int[] array)
        {
            int sum = 0;
            foreach (var i in array)
            {
                if (i > 0) sum += i;
            }
            return sum;
        }
    }
}
