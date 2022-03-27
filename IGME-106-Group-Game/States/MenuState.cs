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
        /// <summary>
        /// This constructor will instantiate a new MenuState object
        /// </summary>
        /// <param name="game"></param>
        public MenuState(Game1 game)
            : base(game)
        {
            ui = new TitleUI(game);
        }

        // Methods
        /// <summary>
        /// This method will update the menu
        /// </summary>
        public override void Update()
        {
            base.Update();
        }

        /// <summary>
        /// This method will draw the menu
        /// </summary>
        /// <param name="_spriteBatch"></param>
        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }
    }
}
