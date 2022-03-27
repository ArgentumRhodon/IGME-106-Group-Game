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
        private Game1 game;
        private Texture2D gameOverTitleTexture;
        private Texture2D quitTexture;
        private Texture2D continueTexture;

        public DeathUI(Game1 game)
        {
            this.game = game;

            LoadContent();
        }

        public override void LoadContent()
        {
            LoadImages();

            images.Add(new Image(gameOverTitleTexture, game.Graphics.PreferredBackBufferWidth / 2, game.Graphics.PreferredBackBufferHeight / 3, HAlign.Center, VAlign.Middle));
            buttons.Add(new Button(new Image(quitTexture, game.Graphics.PreferredBackBufferWidth / 2, 500, HAlign.Center, VAlign.Top), (State state) => { state.SetNextState(new MenuState(game)); }));
            buttons.Add(new Button(new Image(continueTexture, game.Graphics.PreferredBackBufferWidth / 2, 575, HAlign.Center, VAlign.Top), (State state) => { state.SetNextState(new GameState(game)); }));
        }

        private void LoadImages()
        {
            gameOverTitleTexture = game.Content.Load<Texture2D>("uiAssets\\gameScreen\\gameOverTitle");
            quitTexture = game.Content.Load<Texture2D>("uiAssets\\gameScreen\\quitTitleText");
            continueTexture = game.Content.Load<Texture2D>("uiAssets\\gameScreen\\continueText");
        }
    }
}
