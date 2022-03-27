using IGME106GroupGame.GameObjects;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI.Menus
{
    class GameUI : UserInterface
    {
        // - Fields -
        private Game1 game;
        private Player player;
        private List<Image> hearts;
        private Texture2D heartTexture;
        private Texture2D halfHeartTexture;

        // - Consturctor -
        public GameUI(Game1 game, Player player)
        {
            this.game = game;
            this.player = player;
            hearts = new List<Image>();
            
            LoadContent();
        }

        // - Methods -
        public override void LoadContent()
        {
            LoadImages();

            for (int i = 1; i <= player.Health; i++)
            {
                if(i % 2 == 0)
                {
                    hearts.Add(new Image(heartTexture, 20 + (110 * ((i-1) / 2)), 20, HAlign.Left, VAlign.Top));
                }
                else if(i == player.Health)
                {
                    hearts.Add(new Image(halfHeartTexture, 20 + (110 * (i / 2)), 20, HAlign.Left, VAlign.Top));
                }
            }

            images.AddRange(hearts);
        }

        public void LoadImages()
        {
            heartTexture = game.Content.Load<Texture2D>("uiAssets\\gameScreen\\heart");
            halfHeartTexture = game.Content.Load<Texture2D>("uiAssets\\gameScreen\\halfHeart");
        }

        public override void Update(State state)
        {
            base.Update(state);


        }
    }
}
