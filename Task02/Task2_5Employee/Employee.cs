using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3User;

namespace Task2_5Employee
{
    class Employee:User
    {
        private string position = string.Empty;
        private int workExperience;

        public Employee(string surname, string name) : base(surname, name)
        {
        }

        public Employee(string surname, string name, string patronymic) : base(surname, name, patronymic)
        {
        }

        public Employee(string surname, string name, DateTime dateOfBirth) : base(surname, name, dateOfBirth)
        {
            if (User.CalculateAge(dateOfBirth) < 16) throw new ArgumentException("Too young age for employee");
        }

        public Employee(string surname, string name, string patronymic, DateTime dateOfBirth) : base(surname, name, patronymic, dateOfBirth)
        {
        }
        public override DateTime DateOfBirth
        {
            get
            { return base.DateOfBirth; }
            set
            {
                if (User.CalculateAge(value) < 16) throw new ArgumentException("Too young age for employee");
                base.DateOfBirth = value;
            }
        }
      

        public string Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (User.IsLetterString(value))
                {
                    this.position = value;
                }
                else
                {
                    throw new ArgumentException("Position should contain only letters");
                }
            }
        }

        public int WorkExperience
        {
            get
            {
                return this.workExperience;
            }

            set
            {
                if (value >= 0)
                {
                    this.workExperience = value;
                }
                else
                {
                    throw new ArgumentException("Work experience should have positive value");
                }
            }
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            if (this.Position != string.Empty)
            {
                Console.WriteLine($"Position: {this.Position}");
            }
            else
            {
                Console.WriteLine("Position: No position");
            }

            Console.WriteLine($"Work experience: {this.WorkExperience}");
        }
    }
}
