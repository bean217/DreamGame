using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DreamGame.FontLoader;

namespace DreamGame.States
{
    public class MenuState : State
    {
        private SpriteFont font;

        private List<MenuElement> elements;

        private Texture2D background;

        public string menuDir;

        public MenuState(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Game game, string menuDirname) : base(graphics, spriteBatch, game)
        {
            menuDir = $"{Game1.LOCAL_DIR}Menus/{menuDirname}/";
            elements = new List<MenuElement>();
        }

        public override void LoadContent()
        {
            System.IO.Stream a_stream = new System.IO.FileStream($"{menuDir}Assets/background.jpg", System.IO.FileMode.Open);
            background = Texture2D.FromStream(_graphics.GraphicsDevice, a_stream);
            a_stream.Close();
            font = FontLoader.FontLoader.LoadFont("micross.ttf", 36, _graphics.GraphicsDevice);
            readElementData();
            foreach (var element in elements) {
                element.LoadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var element in elements)
                element.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Rectangle(0, 0, Game1.WIN_WIDTH, Game1.WIN_HEIGHT), Color.White);
            foreach (var element in elements)
                element.Draw(gameTime);
            _spriteBatch.End();
        }

        private void readElementData() {
            string filename = $"{menuDir}elements.txt";
            System.IO.StreamReader file = null;
            try
            {
                file = new System.IO.StreamReader(filename);
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    // '#' represents a comment within a file
                    Console.WriteLine(line);
                    if (line.Length == 0 || (line.Length > 0 && line[0] == '#')) continue;
                    string[] info_tmp = line.Split('=');

                    // checks x dimension
                    if (info_tmp[0].Equals("button"))
                    {
                        string[] b_tmp = info_tmp[1].Split(',');
                        int xPos = (Game1.WIN_WIDTH / 2) - (MenuButton.PX_WIDTH / 2);
                        int yPos = (Game1.WIN_HEIGHT / 2) - (MenuButton.PX_HEIGHT / 2);
                        elements.Add(new MenuButton(xPos, yPos, MenuButton.PX_WIDTH, MenuButton.PX_HEIGHT, b_tmp[0], this, int.Parse(b_tmp[1])));
                        
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Encountered exception while opening file '{filename}': {e}");
            }
            finally
            {
                if (file != null) file.Close();
            }
        }

    }
}
