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

        private Texture2D titleTexture;
        private Texture2D titleArtTexture;
        private Texture2D startButtonTexture;
        private Texture2D startAsGodButtonTexture;
        private Texture2D optionsButtonTexture;
        private Texture2D levelEditorButtonTexture;
        private Texture2D quitButtonTexture;

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
            LoadImages();

            images.Add(new Image(titleArtTexture, 0, 0, HAlign.Left, VAlign.Top));
            images.Add(new Image(titleTexture, 0, 100, HAlign.Left, VAlign.Middle));
            buttons.Add(new Button(new Image(startButtonTexture, 30, 335, HAlign.Left, VAlign.Top), (State state) => { state.NextState = new GameState(game); }));
            buttons.Add(new Button(new Image(startAsGodButtonTexture, 30, 510, HAlign.Left, VAlign.Top), (State state) => { state.NextState = new GameState(game, true); }));
            buttons.Add(new Button(new Image(levelEditorButtonTexture, 30, 685, HAlign.Left, VAlign.Top), (State state) => { (new LevelEditor.Form1()).Show(); }));
            buttons.Add(new Button(new Image(quitButtonTexture, 30, 860, HAlign.Left, VAlign.Top), (State state) => { Environment.Exit(0); }));
        }

        /// <summary>
        /// Loads all of the textures used in the UI
        /// </summary>
        public void LoadImages()
        {
            titleTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\titleTexture");
            titleArtTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\titleArt");
            startButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\startText");
            startAsGodButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\startAsGod");
            optionsButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\optionsText");
            levelEditorButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\levelEditorText");
            quitButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\quitText");
        }
    }
}
