using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

    class UI
    {
        // - Fields -
        protected List<Button> buttons;
        protected List<Image> images;
        protected List<Label> labels;

        // - Constructor -
        public UI()
        {
            buttons = new List<Button>();
            images = new List<Image>();
            labels = new List<Label>();
        }

        // - Methods -
        public virtual void LoadContent()
        {

        }

        public virtual void Update()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            foreach(Button button in buttons)
            {
                button.Draw(sb);
            }

            foreach(Image image in images)
            {
                image.Draw(sb);
            }

            foreach(Label label in labels)
            {
                label.Draw(sb);
            }
        }
    }
}
