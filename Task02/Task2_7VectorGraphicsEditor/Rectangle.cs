using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7VectorGraphicsEditor
{
    class Rectangle : Figure
    {
        private double width;
        private double length;
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public Rectangle(Point p1, Point p2)
        {

            this.FirstPoint = p1;
            this.SecondPoint = p2;
            double side1 = CalculateLength(p1.X, p2.X);
            double side2 = CalculateLength(p1.Y, p2.Y);
            if (side1 >= side2)
            {
                length = side1;
                width = side2;
            }
            else
            {
                length = side2;
                width = side1;
            }
        }

        public double Area => Length * Width;

        public double Perimeter
        { get => 2 * Length + 2 * Width; }
        public double Width { get => width; }
        public double Length { get => length; }

        public override string ToString()
        {
            return "Rectangle";
        }
        public override void WriteInfo()
        {
            Console.WriteLine($"Points: ({FirstPoint.X};{FirstPoint.Y}) ({SecondPoint.X};{SecondPoint.Y})");
            Console.WriteLine($"Length: {Length}. Width: {Width}");
            Console.WriteLine($"Perimeter: {Perimeter}");
            Console.WriteLine($"Area: {Area}");
        }
        private double CalculateLength(double x, double y)
        {
            double side;
            if (x > y)
            {
                side = x - y;
            }
            else side = y - x;
            return side;
        }
    }
}
