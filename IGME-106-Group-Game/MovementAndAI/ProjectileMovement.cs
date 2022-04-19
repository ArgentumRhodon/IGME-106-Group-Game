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
        private Vector2 p_1;
        private Vector2 p_2;

        public ProjectileMovement(Vector2 p_1, Vector2 p_2, float speed)
            : base(speed)
        {
            this.p_1 = p_1;
            this.p_2 = p_2;
        }

        public override void Update()
        {
            // Subtracting an extra 16 in x and y to account for the projectil'es width and height, that
            // way the projecile's center travels in line with the mouse instead of the corner.
            Vector2 direction = p_2 - p_1 - new Vector2(16, 16);

            vector = new Vector2(direction.X, direction.Y);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }
            vector *= speed;
        }
    }
}
