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

        private Map map;

        // By tile number
        private Vector2 Position;

        private Texture2D texture;

        private Rectangle drawRect;

        public Tile(int x, int y, Map map) {
            Position = new Vector2(x, y);
            drawRect = new Rectangle(x, y, TILE_SIZE, TILE_SIZE);
            this.map = map;}

        public void LoadContent() {
            // load texture here from content manager
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(map.tileTexture, drawRect, Color.Aqua);
        }


    }
}
