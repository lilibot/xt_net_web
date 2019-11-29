using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1Round
{
    public class Point
    {
        double x;
        double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
