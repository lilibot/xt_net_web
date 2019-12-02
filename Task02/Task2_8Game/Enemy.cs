using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game
{
    class Enemy : Character
    {
        private Random r = new Random();

        public override Point Position { get ; set ; }

        public override void Draw()
        {
            Console.Write("E");
        }

        public override void Move(Map map)
        {
            var direction = this.r.Next(0, 3);
            switch (direction)
            {
                case 0:
                    {
                        Point newLocation = new Point(this.Position.X + 1, this.Position.Y);
                        if (Position.X < map.Width - 1)
                        {
                            this.ChooseAction(map.MapField, this.Position, newLocation);
                        }
                        break;
                    }

                case 1:
                    {
                        Point newLocation = new Point(this.Position.X - 1, this.Position.Y);
                        break;
                    }

                case 2:
                    {
                        Point newLocation = new Point(this.Position.X, this.Position.Y - 1);
                        break;
                    }

                case 3:
                    {
                        Point newLocation = new Point(this.Position.X, this.Position.Y + 1);
                        break;
                    }
            }
        }
        private void ChooseAction(IMapObject[,] map, Point currentLocation, Point newLocation)
        {
            if (map[newLocation.X, newLocation.Y] ==null)
            {

                    map[currentLocation.X, currentLocation.Y] = null;
                    map[newLocation.X, newLocation.Y] = this;
                    this.Position = new Point(newLocation.X, newLocation.Y);
                
            }
        }
    }
}
