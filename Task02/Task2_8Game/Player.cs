using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game
{
    class Player : Character
    {

        public override Point Position { get ;set; }

        public override void Draw()
        {
            Console.Write("P");
        }

        public override void Move(Map map)
        {
            throw new NotImplementedException();
        }
    }
}
