using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using IGME106GroupGame.UI.Menus;

namespace IGME106GroupGame.States
{
    class MenuState : State
    {
        // Fields

        // Constructor
        public MenuState(Game1 game)
            : base(game)
        {
            ui = new TitleUI(game);
        }

        // Methods
        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }
    }
}
