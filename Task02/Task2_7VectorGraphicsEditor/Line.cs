using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7VectorGraphicsEditor
{
    class Line:Figure
    {
        Point firstPoint;
        Point secondPoint;
        internal Point FirstPoint { get => firstPoint; set => firstPoint = value; }
        internal Point SecondPoint { get => secondPoint; set => secondPoint = value; }
        public Line(Point firstPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = new Point();
        }
        public Line(Point firstPoint, Point secondPoint):this(firstPoint)
        {
            SecondPoint = secondPoint;
        }

        public override string ToString()
        {
            return "Line";
        }
        public override void WriteInfo()
        {
            Console.WriteLine($"Points: ({ this.FirstPoint.X};{ this.FirstPoint.Y}) ({ this.SecondPoint.X};{ this.SecondPoint.Y})");
        }
    }
}
