using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame.States
{
    public class MenuState : State
    {

        public MenuState(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Game game) : base(graphics, spriteBatch, game)
        {

        }

        public override void LoadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.End();
        }

    }
}
