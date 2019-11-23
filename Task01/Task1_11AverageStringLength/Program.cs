using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_11AverageStringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();
            int countLetters = 0;
            int countWords = 0;
            bool previousIsLetter = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetterOrDigit(str[i]))
                {
                    countLetters++;
                    previousIsLetter = true;
                }
                else if (previousIsLetter)
                {
                    countWords++;
                    previousIsLetter = false;
                }
            }
            if (char.IsLetterOrDigit(str[str.Length-1])) countWords++;
            Console.WriteLine($"\nКоличество слов: {countWords} \nКоличество букв: {countLetters}\nСреднее количество букв: {countLetters/ countWords}");
            Console.ReadKey();
        }
    }
}
