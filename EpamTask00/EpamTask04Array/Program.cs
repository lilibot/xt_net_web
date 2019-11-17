using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask04Array
{
    class Program
    {
        static void Main(string[] args)
        {

            int count;
            while (true)
            {
                Console.Write("Введите количество массивов: ");
                if (int.TryParse(Console.ReadLine(), out count) && (count > 0))
                {
                    break;
                }
                else Console.WriteLine("Введенное значение отличается от положительного целого числа!");
            }

            int[][] arrays = new int[count][];
            for (int i = 0; i < count; i++)
            {

                int n;
                while (true)
                {
                    Console.Write($"Введите число элементов для {i + 1} массива: ");
                    if (int.TryParse(Console.ReadLine(), out n) && (n > 0))
                    {
                        break;
                    }
                    else Console.WriteLine("Введенное значение отличается от положительного целого числа!");
                }
                arrays[i] = new int[n];
            }
            Console.WriteLine("Сформированный массив:");
            RandomizeArrays(arrays);
            ShowArray(arrays);
            Console.WriteLine("Отсортированный массив:");
            SortArray(arrays);
            ShowArray(arrays);
            Console.ReadKey();

        }

        // fills the arrays with random numbers from 0 to 100
        private static void RandomizeArrays(int[][] arrays)
        {
            Random rand = new Random();
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                    arrays[i][j] = rand.Next(0, 100);
            }
        }

        private static void ShowArray(int[][] arrays)
        {
            Console.Write("{");
            foreach (int[] i in arrays)
            {
                Console.Write("{");
                foreach (int j in i)
                {
                    Console.Write(j.ToString() + ",");
                }
                Console.Write("},");
            }
            Console.WriteLine("}");
        }

        private static void SortArray(int[][] arrays)
        {
            int countTempArray = 0;
            foreach (int[] arr in arrays)
                countTempArray += arr.Length;
            int[] tempArray = new int[countTempArray];
            countTempArray = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    tempArray[countTempArray] = arrays[i][j];
                    countTempArray++;
                }
            }
            Array.Sort(tempArray);
            countTempArray = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    arrays[i][j] = tempArray[countTempArray];
                    countTempArray++;
                }
            }
        }
    }
}
