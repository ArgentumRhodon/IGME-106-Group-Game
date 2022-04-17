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
        private Vector2 startPosition;
        private Vector2 mousePosition;

        public ProjectileMovement(float speed, Vector2 startPosition, Vector2 mousePosition)
            : base(speed)
        {
            this.startPosition = startPosition;
            this.mousePosition = mousePosition;
        }

        public override void Update()
        {
            // Subtracting an extra 16 in x and y to account for the projectil'es width and height, that
            // way the projecile's center travels in line with the mouse instead of the corner.
            Vector2 direction = mousePosition - startPosition - new Vector2(16, 16);

            vector = new Vector2(direction.X, direction.Y);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;
        }
    }
}
