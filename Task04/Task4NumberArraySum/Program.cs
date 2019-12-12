using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4NumberArraySum
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] testArray = new int[] { -1, 5, 5 };
                PrintArray(testArray);
                Console.WriteLine($"Сумма элементов: {testArray.ArraySum()}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        public static int ArraySum(this int[] array)
        {
            if (array == null) throw new ArgumentNullException("array");
            int result = 0;
            foreach (int element in array)
            {
                result += element;
            }
            return result;
        }
        public static void PrintArray<T>(IEnumerable<T> array)
        {
            foreach (var element in array)
            {
                Console.Write(element);
                Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}
