using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame.States
{
    public class GameState : State
    {
        private RoomWrapper _rw;

        public GameState(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Game game, int levelNum) : base(graphics, spriteBatch, game) {
            _rw = new RoomWrapper(levelNum, this);
        }

        public override void LoadContent()
        {
            _rw.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _rw.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _rw.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
        }
    }
}
