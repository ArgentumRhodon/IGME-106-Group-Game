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

        /// <summary>
        /// Updates the movement of an object with a direction vector
        /// </summary>
        /// <param name="direction">the direction vector with which to update the movement</param>
        public void Update(Vector2 direction = default(Vector2))
        {
            float deltaX = 0;
            float deltaY = 0;

            if (direction != default(Vector2))
            {
                deltaX = direction.X;
                deltaY = direction.Y;
            }
            else
            {
                KeyboardState keyboard = Keyboard.GetState();

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
            }

            vector = new Vector2(deltaX, deltaY);
            if(vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;
        }
    }
}
