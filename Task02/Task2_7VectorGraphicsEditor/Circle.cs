using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7VectorGraphicsEditor
{
    class Circle:Figure
    {
        public Point CenterPoint { get; protected set; }
        protected Circle(Point centerPoint)
        {
            CenterPoint = centerPoint;
        }
        public double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Radius value should be more than 0");
                radius = value;
            }
        }
        public virtual double Perimeter
        { get => 2 * Math.PI * radius; }

        public Circle(Point centerPoint, double r):this(centerPoint)
        {
            Radius = r;
        }
        public Circle(double r) : this(new Point())
        {
            Radius = r;
        }

        public override void WriteInfo()
        {
            Console.WriteLine($"Center point: ({CenterPoint.X};{CenterPoint.Y})");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Perimeter: {Perimeter}");
        }
        public override string ToString()
        {
            return "Circle";
        }

    }
}
