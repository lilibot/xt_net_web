using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1Round
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Round round1 = new Round();
                round1.WriteInfo();
                Console.WriteLine();
                Round round2 = new Round(3);
                round2.WriteInfo();
                Console.WriteLine();
                Point point = new Point(3.2, -5);
                Round round3 = new Round(point, 6.4);
                round3.WriteInfo();
                Console.WriteLine();
                Round round4 = new Round(-10);
                round4.WriteInfo();
                Console.WriteLine();
                Console.ReadKey();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
