using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    class Map
    {

        RoomWrapper _rw;

        Tile[,] tiles;

        public Map(RoomWrapper rw) {
            _rw = rw;
            tiles = new Tile[(int)_rw.dimensions.X, (int)_rw.dimensions.Y];
        }

        public void LoadContent() { 
            
        }

        public void Update(GameTime gameTime) { 
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            int i, j;
            for (j = 0; j < (int)_rw.dimensions.Y; j++) {
                for (i = 0; i < (int)_rw.dimensions.X; i++) {
                    tiles[j, i].Draw(gameTime, spriteBatch);
                }
            }
        }
    }
}
