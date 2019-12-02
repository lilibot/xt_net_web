using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game
{
    abstract class Character:IMovable,IMapObject
    {
        public abstract Point Position { get; set; }

        public abstract void Draw();
        public abstract void Move(Map map);

    }
}
