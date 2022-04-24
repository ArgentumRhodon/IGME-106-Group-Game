using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI
{
    public class Assets
    {
        // - Fields -
        private Game1 game;
        private Dictionary<string, Texture2D> textures;

        // - Consturctor -
        public Assets(Game1 game)
        {
            this.game = game;
            textures = new Dictionary<string, Texture2D>();

            LoadContent();
        }

        // - Methods -
        /// <summary>
        /// Gets a texture based on its name
        /// </summary>
        /// <param name="key">The name of the texture</param>
        /// <returns>The texture with the given name</returns>
        public Texture2D Get(string key)
        {
            if(textures.ContainsKey(key))
            {
                return textures[key];
            }

            else
            {
                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Loads all game textures and puts them into a dictionary
        /// </summary>
        private void LoadContent()
        {
            // Game Screen UI Textures
            textures.Add("continueText", game.Content.Load<Texture2D>("uiAssets\\gameScreen\\continueText"));
            textures.Add("gameOverTitle", game.Content.Load<Texture2D>("uiAssets\\gameScreen\\gameOverTitle"));
            textures.Add("halfHeart", game.Content.Load<Texture2D>("uiAssets\\gameScreen\\halfHeart"));
            textures.Add("heart", game.Content.Load<Texture2D>("uiAssets\\gameScreen\\heart"));
            textures.Add("pausedTitle", game.Content.Load<Texture2D>("uiAssets\\gameScreen\\pausedTitle"));
            textures.Add("quitTitleText", game.Content.Load<Texture2D>("uiAssets\\gameScreen\\quitTitleText"));

            // Title Screen UI Textures
            textures.Add("levelEditorText", game.Content.Load<Texture2D>("uiAssets\\titleScreen\\levelEditorText"));
            textures.Add("optionsText", game.Content.Load<Texture2D>("uiAssets\\titleScreen\\optionsText"));
            textures.Add("quitText", game.Content.Load<Texture2D>("uiAssets\\titleScreen\\quitText"));
            textures.Add("startAsGod", game.Content.Load<Texture2D>("uiAssets\\titleScreen\\startAsGod"));
            textures.Add("startText", game.Content.Load<Texture2D>("uiAssets\\titleScreen\\startText"));
            textures.Add("titleArt", game.Content.Load<Texture2D>("uiAssets\\titleScreen\\titleArt"));
            textures.Add("titleTexture", game.Content.Load<Texture2D>("uiAssets\\titleScreen\\titleTexture"));

            // Tiles Textures
            for (int i = 0; i < 5; i++)
            {
                textures.Add($"floor{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\floor\\floor"));
                textures.Add($"northWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\wall\\north"));
                textures.Add($"eastWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\wall\\east"));
                textures.Add($"southWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\wall\\south"));
                textures.Add($"westWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\wall\\west"));
                textures.Add($"topLeftWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\corner\\topLeft"));
                textures.Add($"topRightWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\corner\\topRight"));
                textures.Add($"bottomLeftWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\corner\\bottomLeft"));
                textures.Add($"bottomRightWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\corner\\bottomRight"));
                textures.Add($"invertedTopLeftWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\outCorners\\topLeft"));
                textures.Add($"invertedTopRightWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\outCorners\\topRight"));
                textures.Add($"invertedBottomLeftWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\outCorners\\bottomLeft"));
                textures.Add($"invertedBottomRightWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\outCorners\\bottomRight"));
                textures.Add($"centerWall{i}", game.Content.Load<Texture2D>($"Tiles\\{i}\\wall\\center"));
            }

            // Game Objects Textures
            textures.Add("base", game.Content.Load<Texture2D>("base"));
            textures.Add("ninja", game.Content.Load<Texture2D>("gameObjects\\ninja"));
            textures.Add("meleeNinja", game.Content.Load<Texture2D>("gameObjects\\meleeNinja"));
            textures.Add("slimeBot", game.Content.Load<Texture2D>("gameObjects\\slimeBot"));
            textures.Add("player", game.Content.Load<Texture2D>("gameObjects\\player"));
            textures.Add("enemyStar", game.Content.Load<Texture2D>("gameObjects\\enemyStar"));
            textures.Add("playerStar", game.Content.Load<Texture2D>("gameObjects\\playerStar"));
        }
    }
}
