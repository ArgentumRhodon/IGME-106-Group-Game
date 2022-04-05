using LevelEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            images.Add(new Image(game.Assets.Get("titleArt"), 0, 0, HAlign.Left, VAlign.Top));
            images.Add(new Image(game.Assets.Get("titleTexture"), 0, 100, HAlign.Left, VAlign.Middle));
            buttons.Add(new Button(new Image(game.Assets.Get("startText"), 30, 335, HAlign.Left, VAlign.Top), (State state) => { state.NextState = new GameState(game); }));
            buttons.Add(new Button(new Image(game.Assets.Get("startAsGod"), 30, 510, HAlign.Left, VAlign.Top), (State state) => { state.NextState = new GameState(game, true); }));
            buttons.Add(new Button(new Image(game.Assets.Get("levelEditorText"), 30, 685, HAlign.Left, VAlign.Top), (State state) => { (new LevelEditor.Form1()).Show(); }));
            buttons.Add(new Button(new Image(game.Assets.Get("quitText"), 30, 860, HAlign.Left, VAlign.Top), (State state) => { Environment.Exit(0); }));
        }
    }
}
