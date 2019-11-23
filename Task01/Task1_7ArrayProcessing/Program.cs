using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_7ArrayProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[15];
            Random rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                array[i] = rand.Next(-100, 100);
            }
            Console.WriteLine("Исходный массив: ");
            foreach (var i in array) Console.Write($"{i} ");
            ArraySort(array);
            Console.WriteLine("\nОтсортированный массив: ");
            foreach (var i in array) Console.Write($"{i} ");
            Console.ReadKey();
        }

        public static void ArraySort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
