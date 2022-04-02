using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.MovementAndAI
{
    public class PlayerMovement : Movement
    {
        private KeyboardState keyboard;

        public PlayerMovement(float speed)
            : base(speed)
        {

        }

        public void Update(Vector2 position, Vector2 size)
        {
            float deltaX = 0;
            float deltaY = 0;

            keyboard = Keyboard.GetState();

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
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;

            if (position.X + vector.X < 30 || position.X + size.X + vector.X > 1890)
            {
                vector.X = 0;
            }
            if (position.Y + vector.Y < 30 || position.Y + size.Y + vector.Y > 1050)
            {
                vector.Y = 0;
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
