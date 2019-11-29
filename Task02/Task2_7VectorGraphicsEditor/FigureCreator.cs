using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7VectorGraphicsEditor
{
    static class FigureCreator
    {
        public static Line CreateLine()
        {
            Console.WriteLine("Enter coordinates of first point: ");
            Point firstPoint = CreatePoint();
            Console.WriteLine("Enter coordinates of second point: ");
            Point secondPoint = CreatePoint();
            return new Line(firstPoint, secondPoint);
        }

        public static Circle CreateCircle()
        {
            Console.WriteLine("Enter coordinates of point: ");
            Point pointCenter = CreatePoint();

            Console.WriteLine("Enter radius: ");
            Console.Write("Radius: ");
            int r;
            while (!int.TryParse(Console.ReadLine(), out r))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter radius again: ");
            }

            return new Circle(pointCenter, r);
        }

        public static Round CreateRound()
        {
            Console.WriteLine("Enter coordinates of point: ");
            Point pointCenter = CreatePoint();

            Console.WriteLine("Enter radius: ");
            int r;
            while (!int.TryParse(Console.ReadLine(), out r))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter radius again: ");
            }

            return new Round(pointCenter, r);
        }

        public static Ring CreateRing()
        {
            Console.WriteLine("Enter coordinates of point: ");
            Point pointCenter = CreatePoint();

            Console.WriteLine("Enter inner radius: ");
            int innerR;
            while (!int.TryParse(Console.ReadLine(), out innerR))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter inner radius again: ");
            }

            Console.WriteLine("Enter outer radius: ");
            int outerR;
            while (!int.TryParse(Console.ReadLine(), out outerR))
            {
                Console.WriteLine("Incorrect value: Radius must be positive number");
                Console.WriteLine("Enter outer radius again: ");
            }

            return new Ring( pointCenter, outerR, innerR);
        }

        public static Rectangle CreateRectangle()
        {
            Console.WriteLine("Enter coordinates of first point: ");
            Point pointFirst = CreatePoint();
            Console.WriteLine("Enter coordinates of second point: ");
            Point pointSecond = CreatePoint();
            return new Rectangle(pointFirst, pointSecond);
        }

        public static Point CreatePoint()
        {
            Console.Write("X: ");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Incorrect value: Coordinate X should be a number");
                Console.WriteLine("Enter X: ");
            }

            Console.Write("Y: ");
            int y;
            while (!int.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Incorrect value: Coordinate Y should be a number");
                Console.WriteLine("Enter Y: ");
            }

            Console.WriteLine();
            return new Point(x, y);
        }
    }
}
