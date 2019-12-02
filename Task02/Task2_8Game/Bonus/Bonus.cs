using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game.Bonus
{
    abstract class Bonus : IMapObject, ILoot
    {
        Point ILocatable.Position { get ; set ; }

        public virtual void Draw()
        {
            Console.Write("B");
        }

        public virtual void Loot()
        {

        }
    }

}
