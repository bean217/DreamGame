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
            System.IO.Stream a_stream = new System.IO.FileStream($"{Game1.LOCAL_DIR}Assets/tile1.png", System.IO.FileMode.Open);
            texture = Texture2D.FromStream(map._rw.state._graphics.GraphicsDevice, a_stream);
            a_stream.Close();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, drawRect, Color.Aqua);
        }


    }
}
