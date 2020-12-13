using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame.States
{
    public class MenuButton : MenuElement
    {
        public static readonly int PX_WIDTH = 300;
        public static readonly int PX_HEIGHT = 75;

        public string buttonName;
        private Dictionary<string, Texture2D> textures;
        private Texture2D current;

        private MouseState oldState;
        private int action;

        public MenuButton(int xPos, int yPos, int width, int height, string buttonName, MenuState state, int action) : base(xPos, yPos, width, height, state) {
            this.buttonName = buttonName;
            oldState = Mouse.GetState();
            textures = new Dictionary<string, Texture2D>();
            this.action = action;
        }
        public override void Draw(GameTime gameTime)
        {
            state._spriteBatch.Draw(current, drawRect, Color.White);
        }

        public override void LoadContent()
        {
            System.IO.Stream a_stream = new System.IO.FileStream($"{Game1.LOCAL_DIR}Assets/{buttonName}Button.png", System.IO.FileMode.Open);
            textures.Add("Default", Texture2D.FromStream(state._graphics.GraphicsDevice, a_stream));
            a_stream.Close();
            current = textures["Default"];
            a_stream = new System.IO.FileStream($"{Game1.LOCAL_DIR}Assets/{buttonName}ButtonHover.png", System.IO.FileMode.Open);
            textures.Add("Hover", Texture2D.FromStream(state._graphics.GraphicsDevice, a_stream));
            a_stream.Close();
            a_stream = new System.IO.FileStream($"{Game1.LOCAL_DIR}Assets/{buttonName}ButtonPress.png", System.IO.FileMode.Open);
            textures.Add("Press", Texture2D.FromStream(state._graphics.GraphicsDevice, a_stream));
            a_stream.Close();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (current == textures["Press"]) {
                if (action < 0) { state._game.Exit(); }
                else { state.ChangeState(new GameState(state._graphics, state._spriteBatch, state._game, action)); }
            }

            if (mouseState.X > position.X && mouseState.X < position.X + PX_WIDTH && mouseState.Y > position.Y && mouseState.Y < position.Y + PX_HEIGHT) {
                if (mouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    current = textures["Press"];
                }
                else
                {
                    current = textures["Hover"];
                }
            }
            else {
                current = textures["Default"];
            }
            oldState = mouseState;
        }
    }
}
