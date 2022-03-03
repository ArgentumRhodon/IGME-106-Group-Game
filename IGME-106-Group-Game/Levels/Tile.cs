using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.Levels
{
    class Tile
    {
        // Fields
        private Texture2D sprite;
        
        // Constructor
        public Tile(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        // Methods
        public void Draw(SpriteBatch _spriteBatch, Vector2 position)
        {
            _spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
