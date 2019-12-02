using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game.Bonus
{
    class Apple:Bonus
    {
        public override void Draw()
        {
            Console.Write("A");
        }

        public override void Loot()
        {
            Console.WriteLine("Add hp");
        }
    }
}
