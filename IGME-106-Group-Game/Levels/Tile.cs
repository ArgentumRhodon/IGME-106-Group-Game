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

        // Properties
        public Texture2D Sprite => sprite;
        
        // Constructor
        /// <summary>
        /// This constructor will instantiate a new Tile class, with input sprite
        /// </summary>
        /// <param name="sprite">The sprite to use for the tile</param>
        public Tile(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        // Methods
        /// <summary>
        /// This method will draw the tile to the screen
        /// </summary>
        /// <param name="_spriteBatch"></param>
        /// <param name="position">The position of the tile on the screen</param>
        public void Draw(SpriteBatch _spriteBatch, Vector2 position)
        {
            _spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
