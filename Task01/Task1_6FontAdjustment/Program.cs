using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_6FontAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            TextStyle currentStyles = TextStyle.None;
            while (true)
            {

                Console.WriteLine("Параметры надписи: "+ currentStyles);
                Console.WriteLine("Введите:");
                Console.WriteLine("\t {0}: {1}", 1, TextStyle.bold);
                Console.WriteLine("\t {0}: {1}", 2, TextStyle.italic);
                Console.WriteLine("\t {0}: {1}", 3, TextStyle.underline);

                int pickedOption;
                while (!(int.TryParse(Console.ReadLine(), out pickedOption)&& 1<=pickedOption&& pickedOption <= 3))
                {
                    Console.WriteLine("Введено некорректное значение, введите целое положительное число от 1 до 3");
                }

                switch (pickedOption)
                {
                    case 1:
                        {
                            if ((currentStyles & TextStyle.bold) == 0)
                                currentStyles += (byte)TextStyle.bold;
                            else
                                currentStyles -= (byte)TextStyle.bold;
                            break;
                        }
                    case 2:
                        {
                            if ((currentStyles & TextStyle.italic) == 0)
                                currentStyles += (byte)TextStyle.italic;
                            else
                                currentStyles -= (byte)TextStyle.italic;
                            break;
                        }
                    case 3:
                        {
                            if ((currentStyles & TextStyle.underline) == 0)
                                currentStyles += (byte)TextStyle.underline;
                            else
                                currentStyles -= (byte)TextStyle.underline;
                            break;
                        }

                }

            }
        }
        [Flags]
        enum TextStyle: byte
        {
            None=0,
            bold=1,
            italic=2,
            underline=4
        }
    }
}
