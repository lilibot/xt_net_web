using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        private DateTime dateOfBirth;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age
        {
            get
            {
                return CalculateAge(dateOfBirth);
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
        public IList<int> Awards { get; } = new List<int>();
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
        public override string ToString()
        {
            return $"ID: {Id}. Name: {Name}. DateOfBirth: {DateOfBirth:D} Age: {Age}.";
        }
    }
}
