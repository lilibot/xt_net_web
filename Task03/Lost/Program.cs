using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            int personCount = 0;
            while (true)
            {
                Console.Write("Введите количество человек: ");
                if (int.TryParse(Console.ReadLine(), out personCount) && (personCount > 0))
                {
                    break;
                }
                else Console.WriteLine("Введенное значение отличается от положительного целого числа!");
            }
            List<Person> persons = new List<Person>(personCount);

            for (int i = 0; i < personCount; i++)
            {
                while (true)
                {
                    Console.Write($"Введите имя {i + 1} человека: ");
                    try
                    {
                        Person person = new Person(Console.ReadLine());
                        persons.Add(person);
                        break;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            CollectionsExtension.RemoveEverySecondElement(persons);
            Console.WriteLine("Результат:");
            foreach (var person in persons) { Console.WriteLine(person.Name); }

            Console.ReadKey();
        }

    }
}
