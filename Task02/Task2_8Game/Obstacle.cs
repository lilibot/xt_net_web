using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game
{
     class Obstacle : IMapObject
    {
        public Point Position { get; set; }

        public void Draw()
        {
            Console.Write("*");
        }
    
    }
}
