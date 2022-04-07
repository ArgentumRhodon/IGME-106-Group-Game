using IGME106GroupGame.States;
using System;

namespace IGME106GroupGame.UI.Menus
{
    class TitleUI : UserInterface
    {
        // - Fields -
        private Game1 game;

        private LevelEditor.Form1 levelEditorForm;

        // - Constuctor -
        public TitleUI(Game1 game)
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
            images.Add(new Image(game.Assets.Get("titleArt"), 0, 0, Alignment.Begin, Alignment.Begin, game.Graphics));
            images.Add(new Image(game.Assets.Get("titleTexture"), 0, 50, Alignment.Middle, Alignment.Begin, game.Graphics));
            buttons.Add(new Button(new Image(game.Assets.Get("startText"), 30, 335, Alignment.Begin, Alignment.Begin, game.Graphics), (State state) => { state.NextState = new GameState(game); }));
            buttons.Add(new Button(new Image(game.Assets.Get("startAsGod"), 30, 510, Alignment.Begin, Alignment.Begin, game.Graphics), (State state) => { state.NextState = new GameState(game, true); }));
            buttons.Add(new Button(new Image(game.Assets.Get("levelEditorText"), 30, 685, Alignment.Begin, Alignment.Begin, game.Graphics), (State state) => { (new LevelEditor.Form1()).Show(); }));
            buttons.Add(new Button(new Image(game.Assets.Get("quitText"), 30, 860, Alignment.Begin, Alignment.Begin, game.Graphics), (State state) => { Environment.Exit(0); }));
        }
    }
}
