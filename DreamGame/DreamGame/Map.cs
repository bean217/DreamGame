using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    public class Map
    {

        public RoomWrapper _rw;

        // In pixels
        public Vector2 size;

        // In pixels
        public Vector2 offset;

        public Dictionary<GameObjectType, Texture2D> gameObjectTextures; // HOLDS MAP RELATED TEXTURES, <NOT COMPLETE>

        private Tile[,] tiles;

        public Texture2D tileTexture;

        public Map(RoomWrapper rw) {
            _rw = rw;

            gameObjectTextures = new Dictionary<GameObjectType, Texture2D>();
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
            offset = new Vector2(startx, starty);


            var values = Enum.GetValues(typeof(GameObjectType));
            foreach (GameObjectType value in values)
            {
                System.IO.Stream b_stream = new System.IO.FileStream($"{Game1.LOCAL_DIR}Rooms/Room1/Assets/" + value.ToString() + ".png", System.IO.FileMode.Open);
                gameObjectTextures.Add(value, Texture2D.FromStream(_rw.state._graphics.GraphicsDevice, b_stream));
                b_stream.Close();
            }

            System.IO.Stream a_stream = new System.IO.FileStream($"{Game1.LOCAL_DIR}Assets/tile1.png", System.IO.FileMode.Open);
            tileTexture = Texture2D.FromStream(_rw.state._graphics.GraphicsDevice, a_stream);
            a_stream.Close();


            // load textures here
            tiles = new Tile[(int)_rw.dimensions.Y, (int)_rw.dimensions.X];
            for (j = 0; j < _rw.dimensions.Y; j++) {
                for (i = 0; i < _rw.dimensions.X; i++) {
                    tiles[j, i] = new Tile(startx + i * Tile.TILE_SIZE, starty + j * Tile.TILE_SIZE, this);
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

        public void LoadMapTextures() { 
            
        }
    }
}
