using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.MovementAndAI
{
    class ProjectileMovement : Movement
    {
        private Vector2 direction;

        public ProjectileMovement(float speed, Vector2 startPosition, Vector2 mousePosition)
            : base(speed)
        {
            this.direction = mousePosition - startPosition;
        }

        public override void Update()
        {
            float deltaX = 0;
            float deltaY = 0;

            deltaX = direction.X;
            deltaY = direction.Y;

            vector = new Vector2(deltaX, deltaY);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;
        }
    }
}
