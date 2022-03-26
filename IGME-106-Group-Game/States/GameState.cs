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
    class GameState : State
    {
        // Fields
        // private Player player;
        private Level level;
        private GenericEntity genericEntity;
        private bool paused;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;



        // Constructor
        public GameState(Game1 game)
            : base(game)
        {
            paused = false;
            level = new Level(game.Content);
            genericEntity = new GenericEntity(game.Content.Load<Texture2D>("base"), new Vector2(300, 300));

            ui = new GameUI();
        }

        // Methods
        public override void Update()
        {
            base.Update();

            currentKeyboardState = Keyboard.GetState();

            if (NewKeyPressed(Keys.E))
            {
                paused = !paused;
            }

            //GameState logic
            if (!paused)
            {
                level.Update();
                genericEntity.Update();
            }

            previousKeyboardState = currentKeyboardState;
        }

        private bool NewKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

            // GameState rendering
            level.Draw(_spriteBatch);
            genericEntity.Draw(_spriteBatch);
        }
    }
}
