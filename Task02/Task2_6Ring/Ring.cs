using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1Round;

namespace Task2_6Ring
{
    class Ring
    {
        Point centerPoint;
        double innerR;
        double outerR;

        public double InnerRadius
        {
            get
            {
                return innerR;
            }
            private set
            {
            }
        }
        public double OuterRadius
        {
            get
            {
                return outerR;
            }
            private set
            {
            }
        }
        public double Perimeter
        { get => 2 * Math.PI * InnerRadius+ 2 * Math.PI * OuterRadius; }
        public double Area
        { get => (Math.PI * OuterRadius * OuterRadius)-(Math.PI * InnerRadius * InnerRadius); }
        public Point CenterPoint { get => centerPoint; }

        public Ring(Point point, double innerR, double outerR)
        {
            if ((innerR <= 0) || (outerR <= 0) || (outerR < innerR))
                throw new ArgumentException("Radius value should be more than 0 and InnerRadius should be less than outer");
            this.centerPoint = point;
            this.innerR = innerR;
            this.outerR = outerR;
        }

        public void WriteInfo()
        {
            Console.WriteLine($"Center point: ({centerPoint.X};{centerPoint.Y})");
            Console.WriteLine($"Inner radius: {InnerRadius}. Outer radius: {OuterRadius}.");
            Console.WriteLine($"Perimeter: {Perimeter}");
            Console.WriteLine($"Area: {Area}");
        }

    }
}
