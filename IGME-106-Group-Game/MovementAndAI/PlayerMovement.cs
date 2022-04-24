using IGME106GroupGame.GameObjects;
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
        private Player player;

        public PlayerMovement(float speed, Player player)
            : base(speed)
        {
            this.player = player;
        }

        public override void Update()
        {
            float deltaX = 0;
            float deltaY = 0;

            keyboard = Keyboard.GetState();

            // Movement based on keyboard input
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

            // Normalize movement for consisten diagonal velocity
            vector = new Vector2(deltaX, deltaY);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;

            //// Hard-coded wall collisions
            //if (player.Position.X + vector.X < 60 || player.Position.X + player.CollisionBox.Width + vector.X > 1860)
            //{
            //    vector.X = 0;
            //}
            //if (player.Position.Y + vector.Y < 60 || player.Position.Y + player.CollisionBox.Width + vector.Y > 1020)
            //{
            //    vector.Y = 0;
            //}
        }
    }
}
