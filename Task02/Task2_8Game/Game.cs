﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8Game
{
    class Game
    {
        private Map map;
        public Game()
        {
            this.map = new Map();
        }

        public void StartGame()
        {
            map.DrawMap();
        }
    }
}
