using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace DreamGame
{
    public abstract class GameObject
    {
        private RoomWrapper _rw;
        private Vector2 Position;
        private Rectangle drawRect;


        public GameObject(int width, int height, RoomWrapper rw) {
            _rw = rw;
            Position = new Vector2(rw.map.offset.X, rw.map.offset.Y);
            drawRect = new Rectangle((int)Position.X, (int)Position.Y, width, height);
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
