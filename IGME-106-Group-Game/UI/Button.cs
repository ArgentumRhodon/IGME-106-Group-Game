using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.UI
{
    public class Button
    {
        // - Fields -
        private Image image;
        private Label label;
        private readonly Action<State> clickAction;
        private Color tint;

        // - Properties -
        /// <summary>
        /// The x value of the button, which is also the x value of the image's button and text
        /// </summary>
        public int X
        {
            get { return image.X; }
            set
            {
                image.X = value;
                label.X = value;
            }
        }

        /// <summary>
        /// The y value of the button, which is also the y value of the image's button and text
        /// </summary>
        public int Y
        {
            get { return image.Y; }
            set
            {
                image.Y = value;
                label.Y = value;
            }
        }

        public Color Tint
        {
            get => tint;
            set => tint = value;
        }

        // - Constructor -
        public Button(Image image, Action<State> clickAction, Label label = null)
        {
            this.image = image;
            this.label = label;
            this.clickAction = clickAction;
        }

        // - Methods -
        /// <summary>
        /// Draws the image and label that make up the button
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            image.Draw(sb, tint);
            if(label != null)
            {
                label.Draw(sb);
            }
        }

        /// <summary>
        /// Determines if a given vector is intersecting with the button
        /// </summary>
        public bool IsIntersecting(Vector2 point)
        {
            Rectangle rectangle = image.CollisionBox;
            return point.X > rectangle.X && point.X < rectangle.X + rectangle.Width
                && point.Y > rectangle.Y && point.Y < rectangle.Y + rectangle.Height;
        }

        public void OnClick(State state)
        {
            clickAction(state);
        }
    }
}
