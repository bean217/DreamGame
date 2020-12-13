using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DreamGame.States;

namespace DreamGame
{
    public class Game1 : Game
    {
        public static readonly string LOCAL_DIR = System.IO.Directory.GetCurrentDirectory() + "/";
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly int WIN_WIDTH = 1280;
        public static readonly int WIN_HEIGHT = 720;

        public State current;

        // testing
        public SpriteFont testfont;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = WIN_WIDTH;
            _graphics.PreferredBackBufferHeight = WIN_HEIGHT;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            current = new MenuState(_graphics, _spriteBatch, this, "Main");//new GameState(_graphics, _spriteBatch, this, 1);
            current.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            current.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            
            current.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
