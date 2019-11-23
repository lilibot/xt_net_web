using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_5SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum=0;
            for (int i=3;i<1000;i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0)) sum += i;
            }
            Console.Write($"Сумма чисел, которые <1000, кратные 3 или 5: {sum}");
            Console.ReadKey();
        }
    }
}
