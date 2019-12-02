using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game
{
    class Point
    {
        int x;
        int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
