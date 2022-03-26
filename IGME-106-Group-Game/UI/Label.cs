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
        private HAlign hAlign;
        private VAlign vAlign;
        
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
        public Label(string text, SpriteFont font, int x, int y, Color tint, HAlign hAlign = HAlign.Left, VAlign vAlign = VAlign.Top)
        {
            this.text = text;
            this.font = font;
            position = new Vector2(x, y);
            this.tint = tint;
            this.hAlign = hAlign;
            this.vAlign = vAlign;
        }

        // - Methods -
        /// <summary>
        /// Draws the text label
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            Vector2 drawPosition = position;
            Vector2 size = font.MeasureString(text);

            switch(hAlign)
            {
                case HAlign.Right:
                    drawPosition.X -= size.X;
                    break;

                case HAlign.Center:
                    drawPosition.X -= size.X / 2;
                    break;
            }

            switch(vAlign)
            {
                case VAlign.Bottom:
                    drawPosition.Y -= size.Y;
                    break;

                case VAlign.Middle:
                    drawPosition.Y -= size.Y / 2;
                    break;
            }

            sb.DrawString(font, text, drawPosition, tint);
        }
    }
}
