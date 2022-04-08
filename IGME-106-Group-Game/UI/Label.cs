using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.UI
{
    public class Label
    {
        // - Fields -
        private Alignment hAlign;
        private Alignment vAlign;
        private int windowWidth;
        private int windowHeight;
        
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
        public Label(string text, SpriteFont font, int x, int y, Color tint, Alignment hAlign, Alignment vAlign, GraphicsDeviceManager graphics)
        {
            this.text = text;
            this.font = font;
            position = new Vector2(x, y);
            this.tint = tint;
            this.hAlign = hAlign;
            this.vAlign = vAlign;
            windowWidth = graphics.PreferredBackBufferWidth;
            windowHeight = graphics.PreferredBackBufferHeight;
        }

        // - Methods -
        /// <summary>
        /// Draws the text label and aligns it based on it's horizontal and vertical alignment
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            Vector2 drawPosition = position;
            Vector2 size = font.MeasureString(text);

            switch(hAlign)
            {
                case Alignment.End:
                    drawPosition.X = windowWidth - size.X + X;
                    break;

                case Alignment.Middle:
                    drawPosition.X = windowWidth / 2 - size.X / 2 + X;
                    break;
            }

            switch(vAlign)
            {
                case Alignment.End:
                    drawPosition.Y = windowHeight - size.Y + X;
                    break;

                case Alignment.Middle:
                    drawPosition.Y = windowHeight / 2 - size.Y / 2 + X;
                    break;
            }

            sb.DrawString(font, text, drawPosition, tint);
        }
    }
}
