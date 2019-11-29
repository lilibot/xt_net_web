using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7VectorGraphicsEditor
{
    class Round : Circle
    {
        public Round(Point centerPoint, double r) : base(centerPoint, r) { }
        public Round( double r) : base(r) { }
        public double Area
        {
            get => Math.PI * base.Radius * base.Radius;
        }

        public override void WriteInfo()
        {
            Console.WriteLine($"Center point: ({base.CenterPoint.X};{base.CenterPoint.Y})");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Perimeter: {Perimeter}");
            Console.WriteLine($"Area: {Area}");
        }
        public override string ToString()
        {
            return "Round";
        }
    }

}
