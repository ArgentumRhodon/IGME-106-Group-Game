using IGME106GroupGame.GameObjects;
using IGME106GroupGame.Levels;
using IGME106GroupGame.UI.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.States
{
    public class GameState : State
    {
        // Fields
        private GameObjectHandler gameObjectHandler;

        private Map map;
        private bool paused;
        private bool godMode;
        private PauseUI pauseUI;
        private DeathUI deathUI;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private MouseState currentMouseState;
        private MouseState previousMouseState;

        /// <summary>
        /// This boolean will be used to check if the game is paused
        /// </summary>
        public bool IsPaused
        {
            get => paused;
            set => paused = value;
        }

        public bool GodModeEnabled => godMode;

        // Constructor
        /// <summary>
        /// This constructor will instantiate a new GameState object
        /// </summary>
        /// <param name="game"></param>
        /// <param name="godMode">true for no health, false for regular game</param>
        public GameState(Game1 game, bool godMode = false)
            : base(game)
        {
            this.godMode = godMode;
            paused = false;
            map = new Map(game.Assets, );
            gameObjectHandler = new GameObjectHandler(new Player(Game.Assets.Get("player"), new Vector2(930, 510), godMode));
            ui = new GameUI(game, gameObjectHandler.Player);
            pauseUI = new PauseUI(game);
            deathUI = new DeathUI(game);
        }

        /// <summary>
        /// This method deals with general game updates that exist in the GameState
        /// </summary>
        public override void Update()
        {
            base.Update();

            if(gameObjectHandler.Player.Health <= 0)
            {
                paused = true;
            }

            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            if (NewKeyPressed(Keys.E) && gameObjectHandler.Player.Health > 0)
            {
                paused = !paused;
            }

            //GameState logic
            if (!paused && gameObjectHandler.Player.Health > 0)
            {
                gameObjectHandler.Update(this);
                if (LeftMouseNewlyClicked())
                {
                    gameObjectHandler.AddProjectile(Game.Assets.Get("playerStar"), gameObjectHandler.Player.Position, mouseManager.Position, false, 25);
                    //gameObjectHandler.AddProjectile(this);
                }
            }
            else if(paused && gameObjectHandler.Player.Health > 0)
            {
                pauseUI.Update(this, mouseManager);
            }
            else if(paused)
            {
                deathUI.Update(this, mouseManager);
            }

            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;
        }

        /// <summary>
        /// This method will check to see if a key has just been pressed
        /// </summary>
        /// <param name="key">The key that was pressed</param>
        /// <returns>true if fresh press, false otherwise</returns>
        private bool NewKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// This method will check for a single mouse click
        /// </summary>
        /// <returns>true if fresh click, false otherwise</returns>
        private bool LeftMouseNewlyClicked()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && !(previousMouseState.LeftButton == ButtonState.Pressed);
        }

        /// <summary>
        /// This method will draw enemies, projectiles, and the player to the screen, and also draw UI when applicable
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // GameState rendering
            map.Draw(spriteBatch);

            gameObjectHandler.Draw(spriteBatch);

            ui.Draw(spriteBatch);

            if (paused && gameObjectHandler.Player.Health > 0)
            {
                spriteBatch.Draw(game.Assets.Get("base"), new Rectangle(0, 0, 1920, 1080), new Color(0,0,0,150));
                pauseUI.Draw(spriteBatch);
            }
            else if(paused)
            {
                spriteBatch.Draw(game.Assets.Get("base"), new Rectangle(0, 0, 1920, 1080), new Color(0, 0, 0, 150));
                deathUI.Draw(spriteBatch);
            }
        }
    }
}
