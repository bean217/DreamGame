using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame.States
{
    public abstract class MenuElement
    {
        protected Rectangle drawRect;
        protected Vector2 position;
        protected MenuState state;

        public MenuElement(int xPos, int yPos, int width, int height, MenuState state) {
            drawRect = new Rectangle(xPos, yPos, width, height);
            position = new Vector2(xPos, yPos);
            this.state = state;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
    }
}
