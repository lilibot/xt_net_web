using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game.Bonus
{
    class Cherry:Bonus
    {
        public override void Draw()
        {
            Console.Write("C");
        }

        public override void Loot()
        {
            Console.WriteLine("Add points");
        }
    }
}
