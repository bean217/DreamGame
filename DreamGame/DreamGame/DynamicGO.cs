using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    public enum ColType
    {
        none,
        boundary,
        gameobject
    }

    public class DynamicGO : GameObject
    {
        public DynamicGO(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType, int homeRoom) : base(width, height, rw, type, mType, homeRoom)
        {

        }

        public ColType checkCollision(int x, int y)
        {
            if (x < _rw.map.offset.X)
            {
                return ColType.boundary;
            }
            if (x + size.X > _rw.map.offset.X + _rw.map.size.X)
            {
                return ColType.boundary;
            }
            if (y < _rw.map.offset.Y)
            {
                return ColType.boundary;
            }
            if (y + size.Y > _rw.map.offset.Y + _rw.map.size.Y)
            {
                return ColType.boundary;
            }

            if(_rw.currentRoom.collisionArray[(int)((x - _rw.map.offset.X) / Tile.TILE_SIZE), (int)((y - _rw.map.offset.Y) / Tile.TILE_SIZE)] != null)
            {
                return ColType.gameobject;
            }

            return ColType.none;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            inDream = _rw.currentRoom.roomNum > homeRoom;
            Color color = Color.White;
            if (inDream)
                color = new Color(255, 255, 255, 100);
            spriteBatch.Draw(_rw.map.gameObjectTextures[type], drawRect, color);
        }

        public override void LoadContent()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
