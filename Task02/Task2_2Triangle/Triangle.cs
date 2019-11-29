using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2Triangle
{
    class Triangle
    {
        double a;
        double b;
        double c;

        public double A
        {
            get
            {
                return a;
            }
            set
            {
                if ((b + c < value) || (value <= 0))
                    throw new ArgumentException("The value of the side of the triangle should be more than 0 and less than sum of other sides");
                a = value;
            }
        }

        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if ((a + c < value) || (value <= 0))
                    throw new ArgumentException("The value of the side of the triangle should be more than 0 and less than sum of other sides");
                b = value;
            }
        }
        public double C
        {
            get
            {
                return c;
            }
            set
            {
                if ((b + a < value) || (value <= 0))
                    throw new ArgumentException("The value of the side of the triangle should be more than 0 and less than sum of other sides");
                c = value;
            }
        }
        public double Perimeter
        {
            get
            {
                return a + b + c;
            }
        }
        public double GetArea()
        {
            double semiPerimeter = Perimeter / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
        }

        public Triangle(double a, double b, double c)
        {
            if ((b + a < c) || (a <= 0) || (b <= 0) || (c <= 0))
                throw new ArgumentException("The value of the side of the triangle should be more than 0 and less than sum of other sides");
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void WriteInfo()
        {
            Console.WriteLine($"Sides: {A};{B};{C}");
            Console.WriteLine($"Perimeter: {Perimeter}");
            Console.WriteLine($"Area: {GetArea()}");
        }

    }
}

