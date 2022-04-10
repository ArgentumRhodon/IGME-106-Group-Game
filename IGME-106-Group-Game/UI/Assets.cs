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
            textures.Add("floor", game.Content.Load<Texture2D>("floor"));
            textures.Add("northWall", game.Content.Load<Texture2D>("wall\\north"));
            textures.Add("eastWall", game.Content.Load<Texture2D>("wall\\east"));
            textures.Add("southWall", game.Content.Load<Texture2D>("wall\\south"));
            textures.Add("westWall", game.Content.Load<Texture2D>("wall\\west"));
            textures.Add("topLeftWall", game.Content.Load<Texture2D>("corner\\topLeft"));
            textures.Add("topRightWall", game.Content.Load<Texture2D>("corner\\topRight"));
            textures.Add("bottomLeftWall", game.Content.Load<Texture2D>("corner\\bottomLeft"));
            textures.Add("bottomRightWall", game.Content.Load<Texture2D>("corner\\bottomRight"));

            // Game Objects Textures
            textures.Add("base", game.Content.Load<Texture2D>("base"));
            textures.Add("enemy", game.Content.Load<Texture2D>("gameObjects\\enemy"));
            textures.Add("player", game.Content.Load<Texture2D>("gameObjects\\player"));
            textures.Add("projectile", game.Content.Load<Texture2D>("gameObjects\\projectile"));
            textures.Add("slimeBall", game.Content.Load<Texture2D>("gameObjects\\slimeBall"));
        }
    }
}
