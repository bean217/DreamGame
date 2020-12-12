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

        // In pixels
        public Vector2 size;

        public Dictionary<string, Texture2D> gameObjectTextures; // HOLDS MAP RELATED TEXTURES, <NOT COMPLETE>

        private Tile[,] tiles;

        public Map(RoomWrapper rw) {
            _rw = rw;
        }

        public void LoadContent() {
            // create tile array
            int i, j;

            // set room pixel dimensions
            size.X = (int)_rw.dimensions.X * Tile.TILE_SIZE;
            size.Y = (int)_rw.dimensions.Y * Tile.TILE_SIZE;

            // set the offset based on the dimensions of the map
            int startx = (Game1.WIN_WIDTH / 2) - ((Tile.TILE_SIZE * (int)_rw.dimensions.X) / 2);
            int starty = (Game1.WIN_HEIGHT / 2) - ((Tile.TILE_SIZE * (int)_rw.dimensions.Y) / 2);

            // load textures here
            tiles = new Tile[(int)_rw.dimensions.Y, (int)_rw.dimensions.X];
            for (j = 0; j < _rw.dimensions.Y; j++) {
                for (i = 0; i < _rw.dimensions.X; i++) {
                    tiles[j, i] = new Tile(startx + i * Tile.TILE_SIZE, starty + j * Tile.TILE_SIZE, this);
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
