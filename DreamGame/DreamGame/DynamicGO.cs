﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    public class DynamicGO : GameObject
    {
        public DynamicGO(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType) : base(width, height, rw, type, mType)
        {

        }

        public bool checkCollision(int x, int y)
        {
            if (x < _rw.map.offset.X)
            {
                return true;
            }
            if (x + size.X > _rw.map.offset.X + _rw.map.size.X)
            {
                return true;
            }
            if (y < _rw.map.offset.Y)
            {
                return true;
            }
            if (y + size.Y > _rw.map.offset.Y + _rw.map.size.Y)
            {
                return true;
            }
            if(_rw.currentRoom.collisionArray[(int)((x - _rw.map.offset.X) / Tile.TILE_SIZE), (int)((y - _rw.map.offset.Y) / Tile.TILE_SIZE)] == true)
            {
                return true;
            }

            return false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_rw.map.gameObjectTextures[type], drawRect, Color.White);
        }

        public override void LoadContent()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
