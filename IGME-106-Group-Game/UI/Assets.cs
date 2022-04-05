using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI
{
    class Assets
    {
        // - Fields -
        private Game1 game;
        private Dictionary<string, Texture2D> textures;

        // - Consturctor -
        public Assets(Game1 game)
        {
            this.game = game;
            textures = new Dictionary<string, Texture2D>();
        }

        // - Methods -
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

        private void LoadContent()
        {

        }
    }
}
