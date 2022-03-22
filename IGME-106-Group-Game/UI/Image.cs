using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.UI
{
    class Image
    {
        // - Fields -
        private Texture2D texture;
        private Rectangle rectangle;
        private Color tint;

        // - Properties -
        /// <summary>
        /// The x-value of the image's rectangle
        /// </summary>
        public int X
        {
            get { return rectangle.X; }
            set { rectangle.X = value; }
        }

        /// <summary>
        /// The y-value of the image's rectangle
        /// </summary>
        public int Y
        {
            get { return rectangle.Y; }
            set { rectangle.Y = value; }
        }

        public Rectangle CollisionBox
        {
            get { return rectangle; }
        }

        // - Constructor -
        /// <summary>
        /// The constuctor used if a width and height is not given. Sets values based on texture
        /// </summary>
        public Image(Texture2D texture, int x, int y, Color tint)
            : this(texture, x, y, texture.Width, texture.Height, tint)
        {
            
        }

        public Image(Texture2D texture, int x, int y, int width, int height, Color tint)
        {
            this.texture = texture;
            rectangle = new Rectangle(x, y, width, height);
            this.tint = tint;
        }

        // - Methods -
        /// <summary>
        /// Draws the image
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, rectangle, tint);
        }
    }
}
