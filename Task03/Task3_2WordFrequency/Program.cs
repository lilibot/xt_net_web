using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();
            Dictionary<string, int> textDictionary = GetWordsDictionary(text);
            double wordCount = 0;
            foreach (var word in textDictionary)
            {
                wordCount += word.Value;
            }
            foreach (var word in textDictionary)
            {
                try
                {
                    double wordFrequency = word.Value / wordCount;
                    Console.WriteLine("{0}: {1:N}", word.Key, wordFrequency);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Adds words from text to a dictionary and counts words. 
        /// Words with different case are considered the same. 
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Dictionary of keys - words and values - count of words</returns>
        public static Dictionary<string, int> GetWordsDictionary(string text)
        {
            string textLower = (text + "").ToLower();
            String[] textArray = textLower.Split(new char[] { ' ', '.' });
            Dictionary<string, int> textDictionary = new Dictionary<string, int>();
            foreach (var element in textArray)
            {
                string word=DeletePunctuation(element);
                if (word != "")
                {
                    if (textDictionary.ContainsKey(word))
                    {
                        textDictionary[word]++;
                    }
                    else
                    {
                        textDictionary.Add(word, 1);
                    }
                }
            }
            return textDictionary;
        }

        private static string DeletePunctuation(string str)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    if (char.IsLetterOrDigit(str[i]))
                    {
                        sb.Append(str[i]);
                    }
                }

                return sb.ToString();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            return string.Empty;
        }
    }
}
