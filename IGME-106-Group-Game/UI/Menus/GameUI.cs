using IGME106GroupGame.GameObjects;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
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
        private int wave;
        private Label waveLabel;

        // - Properties -
        public Label WaveLabel
        {
            get => waveLabel;
            set => waveLabel = value;
        }

        // - Consturctor -
        public GameUI(Game1 game, Player player)
        {
            this.game = game;
            this.player = player;
            health = player.Health;
            hearts = new List<Image>();
            waveLabel = new Label("Wave 1", Assets.Fonts["heading"], 0, 20, Color.HotPink, Alignment.Middle, Alignment.Begin, game.Graphics);
            labels.Add(waveLabel);

            UpdateHealth();
        }

        // - Methods -

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

            GameState gameState = (GameState)state;

            if(gameState.Wave <= 5)
            {
                waveLabel.Text = $"Wave {gameState.Wave}";
            }
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
                    hearts.Add(new Image(Assets.Textures["heart"], 20 + (110 * ((i - 1) / 2)), 20, Alignment.Begin, Alignment.Begin, game.Graphics));
                }
                else if (i == player.Health)
                {
                    hearts.Add(new Image(Assets.Textures["halfHeart"], 20 + (110 * (i / 2)), 20, Alignment.Begin, Alignment.Begin, game.Graphics));
                }
            }

            images.AddRange(hearts);
        }
    }
}
