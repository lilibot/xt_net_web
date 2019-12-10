using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы классов: ");

            Console.WriteLine("\nAddRange({ 10, 20, 80, 90 }), AddRange({ 1, 2 }) и Add(100): ");
            DynamicArray<int> testArray = new DynamicArray<int>();
            testArray.AddRange(new int[] { 10, 20, 80, 90 });
            testArray.AddRange(new int[] { 1, 2 });
            testArray.Add(100);
            PrintArray(testArray);

            Console.WriteLine("\n\nRemove(80): ");
            testArray.Remove(80);
            PrintArray(testArray);
            Console.WriteLine();

            Console.WriteLine("\n\nInsert(0,1): ");
            testArray.Insert(0, 1);
            PrintArray(testArray);

            Console.WriteLine("\n\nLength: ");
            Console.WriteLine(testArray.Length);

            Console.WriteLine("\nCapacity: ");
            Console.WriteLine(testArray.Capacity);

            Console.WriteLine("\nCapacity=10: ");
            testArray.Capacity = 10;
            PrintArray(testArray);
            Console.WriteLine("\nCapacity=2: ");
            testArray.Capacity = 2;
            PrintArray(testArray);

            Console.WriteLine("\n\ntestArray[-2]: ");
            Console.WriteLine(testArray[-2]);

            Console.WriteLine("\nЦиклический foreach. Массив { 1, 2, 3 }. 20 итераций: ");
            CycledDynamicArray<int> testArray5 = new CycledDynamicArray<int>();
            testArray5.AddRange(new int[] { 1, 2, 3 });
            int i = 0;
            foreach (var element in testArray5)
            {
                if (i == 20) break;
                Console.WriteLine(element);
                i++;
            }
            Console.ReadKey();
        }
        public static void PrintArray<T>(IEnumerable<T> array)
        {
            foreach (var element in array)
            {
                Console.Write(element);
                Console.Write(", ");
            }
        }
    }
}
