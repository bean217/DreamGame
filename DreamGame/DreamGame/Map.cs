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

        public RoomWrapper _rw;

        private Tile[,] tiles;

        public Map(RoomWrapper rw) {
            _rw = rw;
        }

        public void LoadContent() {
            // create tile array
            int i, j;

            // load textures here

            tiles = new Tile[(int)_rw.dimensions.Y, (int)_rw.dimensions.X];
            for (j = 0; j < _rw.dimensions.Y; j++) {
                for (i = 0; i < _rw.dimensions.X; i++) {
                    tiles[j, i] = new Tile(i, j, this);
                    tiles[j, i].LoadContent();
                }
            }
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
