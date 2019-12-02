using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game
{
    class Map
    {
        private IMapObject[,] map;
        private int width;
        private int length;
        private Random r = new Random();
        private List<Obstacle> obstacles = new List<Obstacle> { };
        private List<Enemy> enemies = new List<Enemy> { };
        private List<Bonus.Bonus> bonuses = new List<Bonus.Bonus> { };
        public int Width { get => width; set => width= value; }
        public int Length { get => length; set => length= value; }
        public Player CurrentPlayer { get; private set; }
        public IMapObject[,] MapField => this.map;
        public Map()
        {
            Width = 10;
            Length = 10;
            InitMap();
            GenerateMapObjects();

        }

        public void InitMap()
        {
            this.map = new IMapObject[this.Length, this.Width];
            for (int i = 0; i < this.Length; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    this.map[i, j] = null;
                }
            }
        }
        public void GenerateMapObjects()
        {
            for (int i = 0; i < Width; i++)
            {
                this.obstacles.Add(new Obstacle());
            }
            this.PutObjectsToField(this.obstacles.ToArray());
            this.enemies.Add(new Enemy());
            this.enemies.Add(new Enemy());
            this.enemies.Add(new Enemy());

            this.PutObjectsToField(this.enemies.ToArray());
            this.bonuses.Add(new Bonus.Apple());
            this.bonuses.Add(new Bonus.Cherry());
            this.bonuses.Add(new Bonus.Apple());
            this.bonuses.Add(new Bonus.Cherry());

            this.PutObjectsToField(this.bonuses.ToArray());

            this.CurrentPlayer = new Player();
            this.PutOneObjectToField(this.CurrentPlayer);

        }
        public void PutObjectsToField(IMapObject[] arr)
        {
            foreach (var e in arr)
            {
                this.PutOneObjectToField(e);
            }
        }
        public void PutOneObjectToField(IMapObject mapObject)
        {
            int i;
            int k;

            while (true)
            {
                i = this.r.Next(0, 10);
                k = this.r.Next(0, 10);
                if (this.map[i, k] == null)
                {
                    this.map[i, k] = mapObject;
                    mapObject.Position = new Point(i, k);
                    break;
                }
            }
        }
        public void DrawMap()
        {
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    if (this.map[i, j] == null)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        this.map[i, j].Draw();
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
