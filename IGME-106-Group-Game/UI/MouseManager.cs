using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI
{
    public class MouseManager
    {
        // fields
        private Vector2 mousePosition;
        private bool leftButtonClicked;
        private MouseState mouse;
        private MouseCursor currentCursor;

        // Properties
        public Vector2 MousePosition => mousePosition;
        public bool LeftButton => leftButtonClicked;

        public MouseCursor CursorStyle
        {
            get => currentCursor;
            set => currentCursor = value;
        }

        // Constructor
        public MouseManager()
        {
            mousePosition = new Vector2(0, 0);
            currentCursor = Microsoft.Xna.Framework.Input.MouseCursor.Arrow;
        }

        // Methods

        public void Update()
        {
            mouse = Mouse.GetState();

            mousePosition = new Vector2(mouse.X, mouse.Y);
            leftButtonClicked = mouse.LeftButton == ButtonState.Pressed;

            Mouse.SetCursor(currentCursor);
            //System.Diagnostics.Debug.WriteLine($"{mouse.X}, {mouse.Y}");
        }
    }
}
