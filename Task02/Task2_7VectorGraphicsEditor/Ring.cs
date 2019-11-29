using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7VectorGraphicsEditor
{
    class Ring:Circle
    {
        double innerRadius;
        public double InnerRadius
        {
            get
            {
                return innerRadius;
            }
            protected set
            {
            }
        }
        public Ring(Point centerPoint, double r, double innerR):base(centerPoint)
        {
            if ((r <= 0) || (innerR <= 0) || (innerR > Radius))
                throw new ArgumentException("Radius value should be more than 0 and InnerRadius should be less than outer");
            CenterPoint = centerPoint;

        }
        public Ring(double r, double innerR) : base(new Point())
        {
            if ((r <= 0) || (innerR <= 0) || (innerR > Radius))
                throw new ArgumentException("Radius value should be more than 0 and InnerRadius should be less than outer");
            InnerRadius = innerR;
            Radius = r;

        }
        public override double Perimeter
        { get => 2 * Math.PI * InnerRadius + 2 * Math.PI * Radius; }
        public double Area
        { get => (Math.PI * Radius * Radius) - (Math.PI * InnerRadius * InnerRadius); }
        public override string ToString()
        {
            return "Ring";
        }
        public override void WriteInfo()
        {
            Console.WriteLine($"Center point: ({base.CenterPoint.X};{base.CenterPoint.Y})");
            Console.WriteLine($"Radius: {Radius}. Inner radius: {InnerRadius}");
            Console.WriteLine($"Perimeter: {Perimeter}");
            Console.WriteLine($"Area: {Area}");
        }

    }
}
