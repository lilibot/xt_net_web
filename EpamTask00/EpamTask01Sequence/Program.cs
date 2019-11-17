using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask00Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberSequence(10));
            Console.ReadKey();
        }
        static StringBuilder NumberSequence(int N)
        {
            if (N <= 0)
            {
                throw new ArgumentException("Argument value should be more than 0");
            }

            StringBuilder stringOfNumberSequences = new StringBuilder();
            for (int i = 1; i <= N; i++)
            {
                stringOfNumberSequences.Append(i);
                if (!(i == N))
                {
                    stringOfNumberSequences.Append(", ");
                }
            }

            return stringOfNumberSequences;

        }
    }
}
