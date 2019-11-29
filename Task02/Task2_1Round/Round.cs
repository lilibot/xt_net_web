using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1Round
{
    class Round
    {

        Point centerPoint;
        double r;

        public double Radius
        {
            get
            {
                return r;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Radius value should be more than 0");
                r = value;
            }
        }
        public double Circumference
        { get => 2 * Math.PI * r; }
        public double Area
        { get => Math.PI * r * r; }
        public Point CenterPoint { get => centerPoint; }

        public Round()
        {
            centerPoint = new Point();
            r = 0;
        }
        public Round(Point point, double r)
        {
            this.centerPoint = point;
            Radius = r;
        }
        public Round(double r) : this()
        {
            Radius = r;
        }
        public void WriteInfo()
        {
            Console.WriteLine($"Center point: ({centerPoint.X};{centerPoint.Y})");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Circumference: {Circumference}");
            Console.WriteLine($"Area: {Area}");
        }
    }
}
