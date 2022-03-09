using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.UI
{
    class Label
    {
        // - Fields -
        private string text;
        private SpriteFont font;
        private Vector2 position;
        private Color tint;

        // - Properties -
        /// <summary>
        /// The x-coordinate of the text label's position
        /// </summary>
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The y-coordinate of the text label's position
        /// </summary>
        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        // - Constructor -
        public Label(string text, SpriteFont font, int x, int y, Color tint)
        {
            this.text = text;
            this.font = font;
            position = new Vector2(x, y);
            this.tint = tint;
        }

        // - Methods -
        /// <summary>
        /// Draws the text label
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, text, position, tint);
        }
    }
}
