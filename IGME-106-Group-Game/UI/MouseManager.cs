using IGME106GroupGame.States;
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
        // Fields
        private Vector2 mousePosition;
        private MouseUser currentUser;

        private MouseState currentState;
        private MouseState previousState;

        // Properties
        public Vector2 Position => mousePosition;
        public MouseUser CurrentUser
        {
            get => currentUser;
            set
            {
                if(currentUser == null)
                {
                    currentUser = value;
                }
            }
        }

        // Constructor
        public MouseManager()
        {
            mousePosition = new Vector2(0, 0);
        }

        // Methods
        /// <summary>
        /// Gets the current mouse state and updates the known position and status of the left mouse button
        /// </summary>
        public void Update(State state)
        {
            currentState = Mouse.GetState();

            mousePosition = new Vector2(currentState.X, currentState.Y);

            // Handle the current user
            if (currentUser != null)
            {
                if (MouseClicked())
                {
                    currentUser.OnClick(state);
                }
            }

            // Clear the current user if nothing happens
            Cleanup();

            previousState = currentState;
        }

        private void Cleanup()
        {
            if(currentState.LeftButton != ButtonState.Pressed)
            {
                currentUser = null;
            }
        }

        public bool MouseClicked()
        {
            // Return if the button was pressed on the previous state but not this one
            return previousState.LeftButton == ButtonState.Pressed && currentState.LeftButton == ButtonState.Released;
        }
    }
}
