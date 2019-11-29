using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3User
{
    public class User
    {
        string surname;
        string name;
        string patronymic;
        DateTime dateOfBirth;
        public string Surname
        {
            get
            { return surname; }
            set
            {
                if (!IsLetterString(value))
                    throw new ArgumentException("Surname should consist only of letters and spaces");
                surname = value;
            }
        }
        public string Name
        {
            get
            { return name; }
            set
            {
                if (!IsLetterString(value))
                    throw new ArgumentException("Name should consist only of letters and spaces");
                name = value;
            }
        }
        public string Patronymic
        {
            get
            { return patronymic; }
            set
            {
                if (!IsLetterString(value))
                    throw new ArgumentException("Patronymic should consist only of letters and spaces");
                patronymic = value;
            }
        }
        public virtual DateTime DateOfBirth
        {
            get
            { return dateOfBirth; }
            set
            {
                if (CalculateAge(value) < 1)
                    throw new ArgumentException("Invalid date of birth. Age should be more than 0");
                dateOfBirth = value;
            }
        }
        public int Age
        {
            get
            { return CalculateAge(dateOfBirth); }

        }

        public User(string surname, string name, string patronymic, DateTime dateOfBirth) : this(surname, name,dateOfBirth)
        {
            Patronymic = patronymic;
        }
        public User(string surname, string name)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = new DateTime(1900, 1, 1);

        }
        public User(string surname, string name, string patronymic):this(surname,name) 
        {
            Patronymic = patronymic;
        }
        public User(string surname, string name, DateTime dateOfBirth) : this(surname, name)
        {
            if (CalculateAge(dateOfBirth) < 1)
                throw new ArgumentException("Invalid date of birth. Age should be more than 0");
            DateOfBirth = dateOfBirth;
        }


        public static bool IsLetterString(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }
        public static int CalculateAge(DateTime birthday)
        {
            var today = DateTime.Today;
            int tempAge = today.Year - birthday.Year;
            if (birthday > today.AddYears(-tempAge))
            {
                tempAge--;
            }
            return tempAge;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Full name: {surname} {name} {patronymic}");
            Console.WriteLine("Date of birth: {0:D}", dateOfBirth);
            Console.WriteLine($"Age: {Age}");
        }

    }
}
