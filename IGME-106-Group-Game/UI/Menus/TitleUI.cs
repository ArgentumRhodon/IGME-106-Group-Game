using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IGME_106_Group_Game;

namespace IGME106GroupGame.UI.Menus
{
    class TitleUI : UI
    {
        // - Fields -
        private Game1 game;
        private GraphicsDeviceManager _graphics;
        private Texture2D titleTexture;
        
        // - Constuctor -
        public TitleUI(Game1 game, GraphicsDeviceManager graphics)
        {
            this.game = game;
            _graphics = graphics;
        }

        // - Methods -
        public override void Initialize()
        {
            images.Add(new Image(titleTexture, _graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 4));
        }

        public override void LoadContent()
        {
            titleTexture = game.Content.Load<Texture2D>("titleTexture");
        }
    }
}
