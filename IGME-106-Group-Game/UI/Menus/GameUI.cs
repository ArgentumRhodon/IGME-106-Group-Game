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
        private int health;
        private List<Image> hearts;
        private Texture2D heartTexture;
        private Texture2D halfHeartTexture;

        // - Consturctor -
        public GameUI(Game1 game, Player player)
        {
            this.game = game;
            this.player = player;
            health = player.Health;
            hearts = new List<Image>();
            
            LoadContent();
        }

        // - Methods -
        /// <summary>
        /// Loads textures for the images and adds all appropriate images to the drawn list
        /// </summary>
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

        /// <summary>
        /// Loads all of the textures used in the UI
        /// </summary>
        public void LoadImages()
        {
            heartTexture = game.Content.Load<Texture2D>("uiAssets\\gameScreen\\heart");
            halfHeartTexture = game.Content.Load<Texture2D>("uiAssets\\gameScreen\\halfHeart");
        }

        /// <summary>
        /// On top of regular UI updating, it also checks if player health changed to update the displayed hearts
        /// </summary>
        /// <param name="state"></param>
        public override void Update(State state, MouseManager mouseManager)
        {
            base.Update(state, mouseManager);

            if(health != player.Health)
            {
                UpdateHealth();
            }

            health = player.Health;
        }

        /// <summary>
        /// Clears the hearts currently drawn and updates them to the player's current health
        /// </summary>
        public void UpdateHealth()
        {
            foreach(Image heart in hearts)
            {
                images.Remove(heart);
            }
            hearts.Clear();

            for (int i = 1; i <= player.Health; i++)
            {
                if (i % 2 == 0)
                {
                    hearts.Add(new Image(heartTexture, 20 + (110 * ((i - 1) / 2)), 20, HAlign.Left, VAlign.Top));
                }
                else if (i == player.Health)
                {
                    hearts.Add(new Image(halfHeartTexture, 20 + (110 * (i / 2)), 20, HAlign.Left, VAlign.Top));
                }
            }

            images.AddRange(hearts);
        }
    }
}
