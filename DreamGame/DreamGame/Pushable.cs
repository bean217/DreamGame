using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    class Pushable : DynamicGO
    {
        public Pushable(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType) : base(width, height, rw, type, mType)
        {

        }

        public bool move(int x, int y)
        {
            if (checkCollision((int)Position.X + x, (int)Position.Y + y) == ColType.none)
            {
                _rw.currentRoom.collisionArray[(int)(((Position.X) - _rw.map.offset.X) / Tile.TILE_SIZE), (int)(((Position.Y) - _rw.map.offset.Y) / Tile.TILE_SIZE)] = null;
                _rw.currentRoom.collisionArray[(int)(((Position.X + x) - _rw.map.offset.X) / Tile.TILE_SIZE), (int)(((Position.Y + y) - _rw.map.offset.Y) / Tile.TILE_SIZE)] = this;

                Position.X += x;
                Position.Y += y;
                setDrawRect();
                return true;
            }
            return false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void LoadContent()
        {

        }


        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
