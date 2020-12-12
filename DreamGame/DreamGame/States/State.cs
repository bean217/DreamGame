using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DreamGame;

namespace DreamGame.States
{
    public abstract class State
    {
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        protected Game _game;

        public State(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Game game) {
            _graphics = graphics;
            _spriteBatch = spriteBatch;
            _game = game;
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        protected void ChangeState(State newState) {
            ((Game1)_game).current = newState;
        }
    }
}
