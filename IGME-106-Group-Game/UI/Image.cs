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
        private Alignment hAlign;
        private Alignment vAlign;
        private int windowWidth;
        private int windowHeight;

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

        /// <summary>
        /// The collision box of the image
        /// </summary>
        public Rectangle CollisionBox
        {
            get { return drawingRect; }
        }

        // - Constructors -
        /// <summary>
        /// The constuctor used if a width, height, and color are not given. Sets dimensions based on texture and defaults the color to white
        /// </summary>
        public Image(Texture2D texture, int x, int y, Alignment hAlign, Alignment vAlign, GraphicsDeviceManager graphics)
            : this(texture, x, y, Color.White, hAlign, vAlign, graphics)
        {

        }

        public Image(Texture2D texture, int x, int y, Color tint, Alignment hAlign, Alignment vAlign, GraphicsDeviceManager graphics)
        {
            this.texture = texture;
            rectangle = new Rectangle(x, y, texture.Width, texture.Height);
            this.tint = tint;
            this.hAlign = hAlign;
            this.vAlign = vAlign;
            windowWidth = graphics.PreferredBackBufferWidth;
            windowHeight = graphics.PreferredBackBufferHeight;
        }

        // - Methods -
        /// <summary>
        /// Draws the image and aligns it based on it's horizontal and vertical alignment
        /// </summary>
        public void Draw(SpriteBatch sb, Color tint)
        {
            drawingRect = rectangle;

            switch(hAlign)
            {
                case Alignment.End:
                    drawingRect.X = windowWidth - rectangle.Width + X;

                    break;

                case Alignment.Middle:
                    drawingRect.X = windowWidth / 2 - rectangle.Width / 2 + X;
                    break;
            }

            switch(vAlign)
            {
                case Alignment.End:
                    drawingRect.Y = windowHeight - rectangle.Height + Y;
                    break;

                case Alignment.Middle:
                    drawingRect.Y = windowHeight / 2 - rectangle.Height / 2 + Y;
                    break;
            }

            sb.Draw(texture, drawingRect, tint);
        }
    }
}
