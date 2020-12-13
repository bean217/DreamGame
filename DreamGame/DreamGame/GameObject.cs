using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace DreamGame
{

    public enum GameObjectType
    {
        none,
        player,
        wall,
        pushable,
        button,
        lava
    }

    public enum MoveType
    {
        none,
        immovable,
        moveable,
        controllable
    }


    public abstract class GameObject
    {
        protected RoomWrapper _rw;
        protected Vector2 Position;
        protected Rectangle drawRect;

        protected GameObjectType type;
        public MoveType mType;

        protected Vector2 size;

        public GameObject(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType) {
            _rw = rw;
            this.type = type;
            this.mType = mType;
            size = new Vector2(width, height);
        }

        public void initRect(int x, int y)
        {
            Position = new Vector2(x, y);
            drawRect = new Rectangle((int)Position.X, (int)Position.Y, (int)size.X, (int)size.Y);
        }

        public void setDrawRect()
        {
            drawRect.X = (int)Position.X;
            drawRect.Y = (int)Position.Y;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
