using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;


namespace IGME106GroupGame.MovementAndAI
{
    class PickupMovement : Movement
    {
        private float deltaX = 0;
        private float deltaY = 0;

        public PickupMovement(float speed)
            : base(speed)
        {
        }

        public void Update(Vector2 startPos, Vector2 endPos)
        {
            deltaX = 0;
            deltaY = 0;

            Vector2 direction = endPos - startPos;

            if (direction.Length() > 500)
            {
                deltaX = direction.X;
                deltaY = direction.Y;
            }

            vector = new Vector2(deltaX, deltaY);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }

            vector *= speed;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
