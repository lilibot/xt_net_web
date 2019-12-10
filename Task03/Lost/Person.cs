using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost
{
    public class Person
    {
        string name;

        public string Name
        {
            get => name;
            set
            {
                if (!IsLetterString(value))
                    throw new ArgumentException("Name should consist only of letters and spaces");
                name = value;
            } 
        }
        public Person(string name)
        {
            Name = name;
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
        public override string ToString()
        {
            return Name;
        }
    }
}
