using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IGME106GroupGame.UI
{
    public enum HAlign
    {
        Left,
        Center,
        Right
    }

    public enum VAlign
    {
        Top,
        Middle,
        Bottom
    }

    public class UserInterface
    {
        // - Fields -
        protected List<Button> buttons;
        protected List<Image> images;
        protected List<Label> labels;
        protected MouseState previousMouseState;

        // - Constructor -
        public UserInterface()
        {
            buttons = new List<Button>();
            images = new List<Image>();
            labels = new List<Label>();
        }

        // - Methods -
        /// <summary>
        /// Loads textures for the UI elements and adds said elements to their respective lists
        /// </summary>
        public virtual void LoadContent()
        {

        }

        /// <summary>
        /// Checks for left mouse clicks on buttons and performs their actions if clicked
        /// </summary>
        public virtual void Update(State state, MouseManager mouseManager)
        {
            foreach(Button button in buttons)
            {
                if (button.ContainsPoint(mouseManager.Position))
                {
                    button.Tint = Color.Cyan;
                    mouseManager.CurrentUser = button;
                }
                else
                {
                    button.Tint = Color.White;
                }
            }
        }

        /// <summary>
        /// Draws all UI elements in the lists
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            foreach(Button button in buttons)
            {
                button.Draw(sb);
            }

            foreach(Image image in images)
            {
                image.Draw(sb, Color.White);
            }

            foreach(Label label in labels)
            {
                label.Draw(sb);
            }
        }
    }
}
