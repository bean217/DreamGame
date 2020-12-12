using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    class Tile
    {
        // Length/Width of a tile in pixels
        public static readonly int TILE_SIZE = 32;

        // By tile number
        private Vector2 Position;

        private Texture2D texture;

        private Rectangle drawRect;

        public Tile(int x, int y) {
            Position = new Vector2(x * TILE_SIZE, y * TILE_SIZE);
            drawRect = new Rectangle(0, 0, TILE_SIZE, TILE_SIZE);
        }

        public void LoadContent() { 
            // load texture here from content manager
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, drawRect, Color.Aqua);
        }


    }
}
