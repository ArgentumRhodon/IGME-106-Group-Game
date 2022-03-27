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
        private MouseState mouseState;
        private MouseCursor currentCursor;
        private Button mouseUser;

        // Properties
        public Vector2 MousePosition => mousePosition;
        public bool LeftButton => leftButtonClicked;
        public Button MouseUser
        {
            get => mouseUser;
            set => mouseUser = value;
        }

        public MouseCursor CursorStyle
        {
            get => currentCursor;
            set => currentCursor = value;
        }

        public MouseState MouseState => mouseState;

        // Constructor
        public MouseManager()
        {
            mousePosition = new Vector2(0, 0);
            currentCursor = Microsoft.Xna.Framework.Input.MouseCursor.Arrow;
        }

        // Methods

        public void Update()
        {
            mouseState = Mouse.GetState();

            mousePosition = new Vector2(mouseState.X, mouseState.Y);
            leftButtonClicked = mouseState.LeftButton == ButtonState.Pressed;

            Mouse.SetCursor(currentCursor);
            //System.Diagnostics.Debug.WriteLine($"{mouse.X}, {mouse.Y}");
        }
    }
}
