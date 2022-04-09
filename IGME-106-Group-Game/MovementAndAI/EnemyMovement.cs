using IGME106GroupGame.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.MovementAndAI
{
    class EnemyMovement : Movement
    {
        private float deltaX = 0;
        private float deltaY = 0;

        public EnemyMovement(float speed)
            : base(speed)
        {

        }

        public void Update(Vector2 enemyPosition, Vector2 playerPosition)
        {
            deltaX = 0;
            deltaY = 0;

            Vector2 direction = playerPosition - enemyPosition;

            //if (enemyPosition.X + vector.X < 60 || enemyPosition.X + enemySize.X + vector.X > 1860)
            //{
            //    canMoveX = false;
            //}
            //if (enemyPosition.Y + vector.Y < 60 || enemyPosition.Y + enemySize.Y + vector.Y > 1020)
            //{
            //    canMoveY = false;
            //}

            //if (direction.Length() > 200)
            //{
            //    if (canMoveX)
            //    {
            //        deltaX = direction.X;
            //    }
            //    if (canMoveY)
            //    {
            //        deltaY = direction.Y;
            //    }
            //}

            // GET COLLISIONS WORKING! (Movement.Stop)

            deltaX = 0;
            deltaY = 1;

            vector = new Vector2(deltaX, deltaY);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }

            vector *= speed;

            Stop(!canMoveX, !canMoveY);

            canMoveX = true;
            canMoveY = true;
        }
        
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
