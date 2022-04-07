using IGME106GroupGame.States;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI.Menus
{
    class DeathUI : UserInterface
    {
        // - Fields -
        private Game1 game;

        // - Constructor -
        public DeathUI(Game1 game)
        {
            this.game = game;

            LoadContent();
        }

        // - Methods -
        /// <summary>
        /// Loads textures for the images and adds all appropriate images to the drawn list
        /// </summary>
        public override void LoadContent()
        {
            images.Add(new Image(game.Assets.Get("gameOverTitle"), game.Graphics.PreferredBackBufferWidth / 2, game.Graphics.PreferredBackBufferHeight / 3, Alignment.Middle, Alignment.Middle, game.Graphics));
            buttons.Add(new Button(new Image(game.Assets.Get("quitTitleText"), game.Graphics.PreferredBackBufferWidth / 2, 500, Alignment.Middle, Alignment.Begin, game.Graphics), (State state) => { state.NextState = new MenuState(game); }));
            buttons.Add(new Button(new Image(game.Assets.Get("continueText"), game.Graphics.PreferredBackBufferWidth / 2, 575, Alignment.Middle, Alignment.Begin, game.Graphics), (State state) => { state.NextState = new GameState(game); }));
        }
    }
}
