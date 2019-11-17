using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask02Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("If the number is simple - true else false");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("{0} - {1}", i, IsSimpleNumber(i));
            }

            Console.ReadKey();
        }
        static Boolean IsSimpleNumber(int N)
        {
            if (N <= 0)
            {
                throw new ArgumentException("Argument value should be more than 0");
            }

            for (int i = 2; i < N; i++)
            {
                if (N % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
