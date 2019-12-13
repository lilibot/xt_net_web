using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ISeekYou
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemsSearchingTests itemsSearching = new ItemsSearchingTests();
            itemsSearching.FillRandomValues(itemsSearching.ListForTests);
            Console.WriteLine("Test simple method");
            itemsSearching.TestWithSimpleMethod();
            Console.WriteLine("Median: " + itemsSearching.TestsMedian);
            Console.WriteLine("Test method with instance of delegate");
            itemsSearching.TestMethodWithPredicate(IsNegative);
            Console.WriteLine("Median: " + itemsSearching.TestsMedian);
            Console.WriteLine("Test method with with delegate by anonymous method");
            itemsSearching.TestMethodWithPredicate(delegate (int x) { return x < 0; });
            Console.WriteLine("Median: " + itemsSearching.TestsMedian);
            Console.WriteLine("Test method with with lambda");
            itemsSearching.TestMethodWithPredicate((x) => x < 0);
            Console.WriteLine("Median: " + itemsSearching.TestsMedian);
            Console.WriteLine("Test method with with LINQ");
            itemsSearching.TestLINQ();
            Console.WriteLine("Median: " + itemsSearching.TestsMedian);
            Console.ReadKey();
        }
        private static bool IsNegative(int x)
        {
            return x < 0;
        }
    }
}
