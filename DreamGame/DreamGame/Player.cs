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
        public Player(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType, int homeRoom) : base(width, height, rw, type, mType, homeRoom) { 
            
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

            Vector2 moveVec = new Vector2(0,0);

            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
            {
                moveVec.Y -= Tile.TILE_SIZE;
                moved = true;
            }
            else if (kstate.IsKeyDown(Keys.Down))
            {
                moveVec.Y += Tile.TILE_SIZE;
                moved = true;
            }
            else if (kstate.IsKeyDown(Keys.Right))
            {
                moveVec.X += Tile.TILE_SIZE;
                moved = true;
            }
            else if (kstate.IsKeyDown(Keys.Left))
            {
                moveVec.X -= Tile.TILE_SIZE;
                moved = true;
            }

            if (moved)
            {
                ColType col = checkCollision((int)(moveVec.X + Position.X), (int)(moveVec.Y + Position.Y));
                if (col == ColType.gameobject)
                {

                    GameObject colObj = _rw.currentRoom.collisionArray[(int)(((moveVec.X + Position.X) - _rw.map.offset.X) / Tile.TILE_SIZE), (int)(((moveVec.Y + Position.Y) - _rw.map.offset.Y) / Tile.TILE_SIZE)];

                    if (colObj != null)
                    {
                        if (colObj.mType == MoveType.moveable)
                        {
                            if (((Pushable)colObj).move((int)moveVec.X, (int)moveVec.Y))
                            {
                                Position.X += moveVec.X;
                                Position.Y += moveVec.Y;
                                setDrawRect();
                                lastTimePressed = (float)gameTime.TotalGameTime.TotalMilliseconds;
                            }
                        }
                    }

                }
                else if (col == ColType.none)
                {
                    Position.X += moveVec.X;
                    Position.Y += moveVec.Y;
                    setDrawRect();
                    lastTimePressed = (float)gameTime.TotalGameTime.TotalMilliseconds;
                }
            }


        }
    }
}
