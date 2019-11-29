using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1Round;

namespace Task2_6Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ring ring1 = new Ring(new Point(),4,6);
                ring1.WriteInfo();
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
