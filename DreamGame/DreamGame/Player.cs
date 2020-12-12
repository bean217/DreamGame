using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    public class Player : DynamicGO
    {
        public Player(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType) : base(width, height, rw, type, mType) { 
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void LoadContent()
        {
            
        }

        private float lastTimePressed;

        public override void Update(GameTime gameTime)
        {
            if ((float)gameTime.TotalGameTime.TotalMilliseconds - lastTimePressed < 200)
            {
                return;
            }

            bool moved = false;

            Vector2 moveVec = new Vector2(Position.X, Position.Y);

            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
            {
                moveVec.Y -= Tile.TILE_SIZE;
                moved = true;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                moveVec.Y += Tile.TILE_SIZE;
                moved = true;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                moveVec.X += Tile.TILE_SIZE;
                moved = true;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                moveVec.X -= Tile.TILE_SIZE;
                moved = true;
            }

            if (moved)
            {
                if (!checkCollision((int)moveVec.X, (int)moveVec.Y))
                {
                    Position = moveVec;
                    setDrawRect();
                    lastTimePressed = (float)gameTime.TotalGameTime.TotalMilliseconds;
                }
            }


        }
    }
}
