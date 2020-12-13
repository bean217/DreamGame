using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DreamGame.States;

namespace DreamGame
{
    class Pushable : DynamicGO
    {
        public Pushable(int width, int height, RoomWrapper rw, GameObjectType type, MoveType mType, int homeRoom) : base(width, height, rw, type, mType, homeRoom)
        {

        }

        public bool move(int x, int y, bool setCol = true)
        {
            if (inDream)
            {
                return true;
            }

            ColType colResult = checkCollision((int)Position.X + x, (int)Position.Y + y);

            if (colResult == ColType.boundary)
            {
                return false;
            }

            GameObject colObj = _rw.currentRoom.collisionArray[(int)(((Position.X + x) - _rw.map.offset.X) / Tile.TILE_SIZE), (int)(((Position.Y + y) - _rw.map.offset.Y) / Tile.TILE_SIZE)];
            //if(colObj != null)
                //Console.WriteLine(colObj.type);
            if (colResult == ColType.none)
            {
                if (setCol)
                {
                    _rw.currentRoom.collisionArray[(int)(((Position.X) - _rw.map.offset.X) / Tile.TILE_SIZE), (int)(((Position.Y) - _rw.map.offset.Y) / Tile.TILE_SIZE)] = null;
                    _rw.currentRoom.collisionArray[(int)(((Position.X + x) - _rw.map.offset.X) / Tile.TILE_SIZE), (int)(((Position.Y + y) - _rw.map.offset.Y) / Tile.TILE_SIZE)] = this;
                }


                Position.X += x;
                Position.Y += y;
                setDrawRect();
                return true;
            }
            else if (colResult == ColType.gameobject)
            {
                if (colObj != null && colObj.type == GameObjectType.button)
                {
                    //Pushable is on a button
                    System.Threading.Thread.Sleep(500);
                    if (_rw.levelNum < 2)
                    {
                        _rw.state.ChangeState(new GameState(_rw.state._graphics, _rw.state._spriteBatch, _rw.state._game, _rw.levelNum + 1));
                    }
                    else
                    {
                        _rw.state.ChangeState(new MenuState(_rw.state._graphics, _rw.state._spriteBatch, _rw.state._game, "End"));
                    }
                }
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
