using IGME106GroupGame.GameObjects;
using IGME106GroupGame.States;
using IGME106GroupGame.UI;
using IGME106GroupGame.UI.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * DEVELOPER'S NOTE:
 * Can now select a file upon launch to load a map into the game.
 * Next step is to get maps to auto-center and choose a standard
 * tile size (width/height).
 */

namespace IGME106GroupGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Fields
        private State state;

        // Properties
        public GraphicsDeviceManager Graphics => _graphics;

        public State State
        {
            get => state;
            set => state = value;
        }

        // Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Texture2D playerSprite = Content.Load<Texture2D>("nameOfPlayerSprite");
            //Texture2D enemySprite = Content.Load<Texture2D>("nameOfEnemSprite");
            //player = new Player(playerSprite, new Vector2(960, 540));

            // TODO: use this.Content to load your game content here
            assets = new Assets(this.Content);
            state = new MenuState(this);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            state.Update();
            //player.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            state.Draw(_spriteBatch);
            //player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
