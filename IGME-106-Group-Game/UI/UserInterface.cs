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
        protected MouseManager mouseManager;
        protected MouseState previousMouseState;

        // - Constructor -
        public UserInterface()
        {
            buttons = new List<Button>();
            images = new List<Image>();
            labels = new List<Label>();
            mouseManager = new MouseManager();
        }

        // - Methods -
        public virtual void LoadContent()
        {

        }

        public virtual void Update(State state)
        {
            mouseManager.Update();

            foreach(Button b in buttons)
            {
                if (b.ContainsPoint(mouseManager.MousePosition))
                {
                    b.Tint = Color.Cyan;
                    if (mouseManager.LeftButton)
                    {
                        mouseManager.MouseUser = b;
                    }
                    if(previousMouseState.LeftButton == ButtonState.Pressed && !mouseManager.LeftButton && mouseManager.MouseUser == b)
                    {
                        b.OnClick(state);
                    }
                }
                else
                {
                    b.Tint = Color.White;
                }
            }

            previousMouseState = mouseManager.MouseState;
        }


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
