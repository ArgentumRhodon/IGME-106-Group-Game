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
            images.Add(new Image(Assets.Textures["titleArt"], 0, 0, Alignment.Begin, Alignment.Begin, game.Graphics));
            images.Add(new Image(Assets.Textures["titleTexture"], 0, 75, Alignment.Begin, Alignment.Begin, game.Graphics));
            buttons.Add(new Button(new Image(Assets.Textures["startText"], 30, -205, Alignment.Begin, Alignment.Middle, game.Graphics), (State state) => { state.NextState = new GameState(game); }));
            buttons.Add(new Button(new Image(Assets.Textures["startAsGod"], 30, -30, Alignment.Begin, Alignment.Middle, game.Graphics), (State state) => { state.NextState = new GameState(game, true); }));
            buttons.Add(new Button(new Image(Assets.Textures["levelEditorText"], 30, 145, Alignment.Begin, Alignment.Middle, game.Graphics), (State state) => { (new LevelEditor.Form1()).Show(); }));
            buttons.Add(new Button(new Image(Assets.Textures["quitText"], 30, 320, Alignment.Begin, Alignment.Middle, game.Graphics), (State state) => { Environment.Exit(0); }));
        }
    }
}
