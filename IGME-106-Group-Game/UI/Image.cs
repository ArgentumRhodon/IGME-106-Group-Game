using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.UI
{
    public class Image
    {
        // - Fields -
        private HAlign hAlign;
        private VAlign vAlign;

        private Texture2D texture;
        private Rectangle rectangle;
        private Rectangle drawingRect;
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
            get { return drawingRect; }
        }

        // - Constructors -
        public Image(Texture2D texture, int x, int y, HAlign hAlign, VAlign vAlign)
            : this(texture, x, y, texture.Width, texture.Height, Color.White, hAlign, vAlign)
        {

        }

        /// <summary>
        /// The constuctor used if a width and height is not given. Sets values based on texture
        /// </summary>
        public Image(Texture2D texture, int x, int y, Color tint, HAlign hAlign, VAlign vAlign)
            : this(texture, x, y, texture.Width, texture.Height, tint, hAlign, vAlign)
        {
            
        }

        public Image(Texture2D texture, int x, int y, int width, int height, HAlign hAlign, VAlign vAlign)
            : this(texture, x, y, width, height, Color.White, hAlign, vAlign)
        {

        }

        public Image(Texture2D texture, int x, int y, int width, int height, Color tint, HAlign hAlign, VAlign vAlign)
        {
            this.texture = texture;
            rectangle = new Rectangle(x, y, width, height);
            this.tint = tint;
            this.hAlign = hAlign;
            this.vAlign = vAlign;
        }

        // - Methods -
        /// <summary>
        /// Draws the image
        /// </summary>
        public void Draw(SpriteBatch sb, Color tint)
        {
            drawingRect = rectangle;

            switch(hAlign)
            {
                case HAlign.Right:
                    drawingRect.X -= rectangle.Width;
                    break;

                case HAlign.Center:
                    drawingRect.X -= rectangle.Width / 2;
                    break;
            }

            switch(vAlign)
            {
                case VAlign.Bottom:
                    drawingRect.Y -= rectangle.Height;
                    break;

                case VAlign.Middle:
                    drawingRect.Y -= rectangle.Height / 2;
                    break;
            }

            sb.Draw(texture, drawingRect, tint);
        }
    }
}
