using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.GameObjects;

namespace IGME106GroupGame.MovementAndAI
{
    class Movement
    {
        // Fields
        private Vector2 vector;
        private float speed;

        // Properties
        public Vector2 Vector => vector;

        // Constructor
        public Movement(float speed)
        {
            this.speed = speed;
            this.vector = new Vector2(0, 0);
        }

        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            int deltaX = 0;
            int deltaY = 0;

            if (keyboard.IsKeyDown(Keys.W))
            {
                deltaY--;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                deltaY++;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                deltaX--;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                deltaX++;
            }

            vector = new Vector2(deltaX, deltaY);
            if(vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;
        }
        public void Update(Player p)
        {
            int deltaX = 0;
            int deltaY = 0;
            MouseState mState = Mouse.GetState();
            Vector2 playerToMouse = new Vector2(mState.Position.X);
            vector = new Vector2(deltaX, deltaY);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;
        }
    }
}
