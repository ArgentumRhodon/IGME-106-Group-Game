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
            images.Add(new Image(Assets.Get("gameOverTitle"), 0, -150, Alignment.Middle, Alignment.Middle, game.Graphics));
            buttons.Add(new Button(new Image(Assets.Get("quitTitleText"), 0, 0, Alignment.Middle, Alignment.Middle, game.Graphics), (State state) => { state.NextState = new MenuState(game); }));
            buttons.Add(new Button(new Image(Assets.Get("continueText"), 0, 100, Alignment.Middle, Alignment.Middle, game.Graphics), (State state) => { state.NextState = new GameState(game); }));
        }
    }
}
