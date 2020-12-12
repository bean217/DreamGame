using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DreamGame.States;

namespace DreamGame
{
    public class Game1 : Game
    {
        public static readonly string LOCAL_DIR = "../../../";
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            current = new GameState(_graphics, _spriteBatch, this, 1);
            current.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            current.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            current.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
