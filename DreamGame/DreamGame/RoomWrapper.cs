using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    class RoomWrapper
    {
        private int levelNum;

        private Map map;

        public Vector2 dimensions
        {
            get;
        }

        public RoomWrapper(int levelNum) {
            this.levelNum = levelNum;
        }

        public void LoadContent() { 
            // read room wrapper data file for dimension info
            // dimensions = .... ;
        }

    }
}
