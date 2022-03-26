﻿using System;
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
        private Texture2D startButtonTexture;
        private Texture2D optionsButtonTexture;
        private Texture2D levelEditorButtonTexture;
        private Texture2D quitButtonTexture;


        // - Constuctor -
        public TitleUI(Game1 game)
        {
            this.game = game;

            LoadContent();
        }

        // - Methods -
        public void LoadImages()
        {
            titleTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\titleTexture");
            startButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\startText");
            optionsButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\optionsText");
            levelEditorButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\levelEditorText");
            quitButtonTexture = game.Content.Load<Texture2D>("uiAssets\\titleScreen\\quitText");
        }

        public override void LoadContent()
        {
            LoadImages();

            images.Add(new Image(titleTexture, game.Graphics.PreferredBackBufferWidth / 2, game.Graphics.PreferredBackBufferHeight / 4, HAlign.Center, VAlign.Middle));
            buttons.Add(new Button(new Image(startButtonTexture, game.Graphics.PreferredBackBufferWidth / 2, 400, HAlign.Center, VAlign.Top), (State state) => { state.SetNextState(new GameState(game)); }));
        }
    }
}
