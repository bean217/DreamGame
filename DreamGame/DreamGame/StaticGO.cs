﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamGame
{
    class StaticGO : GameObject
    {
        public StaticGO(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType, int homeRoom) : base(width, height, rw, type, mType , homeRoom) { 
            
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
