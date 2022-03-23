using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using IGME_106_Group_Game;
using Microsoft.Xna.Framework.Input;

namespace IGME106GroupGame.States
{
    class MenuState : State
    {
        // Fields
        private SpriteFont font;

        // Constructor
        public MenuState(Game1 game)
            : base(game)
        {
            font = game.Content.Load<SpriteFont>("font");
        }

        // Methods
        public override void Update()
        {
            base.Update();

            // Press Space for GameState
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                game.SetState(new GameState(game));
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

            _spriteBatch.DrawString(font, "Press Space for Game State", new Vector2(200, 200), Color.Black);
        }
    }
}
