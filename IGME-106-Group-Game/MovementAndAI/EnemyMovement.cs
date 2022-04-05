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
        private bool canMoveX = true;
        private bool canMoveY = true;

        private float deltaX = 0;
        private float deltaY = 0;

        public EnemyMovement(float speed)
            : base(speed)
        {

        }

        public void Update(Vector2 enemyPosition, Vector2 playerPosition, Vector2 enemySize)
        {
            deltaX = 0;
            deltaY = 0;

            MoveFromPlayer(enemyPosition, playerPosition);

            vector = new Vector2(deltaX, deltaY);
            if (vector.X != 0 || vector.Y != 0)
            {
                vector.Normalize();
            }

            vector *= speed;

            if (enemyPosition.X + vector.X < 60 || enemyPosition.X + enemySize.X + vector.X > 1860)
            {
                vector.X = 0;
            }
            if (enemyPosition.Y + vector.Y < 60 || enemyPosition.Y + enemySize.Y + vector.Y > 1020)
            {
                vector.Y = 0;
            }
        }

        private void MoveFromPlayer(Vector2 thisPosition, Vector2 playerPosition)
        {
            if (Vector2.Distance(thisPosition, playerPosition) < 600)
            {
                if (Vector2.Distance(thisPosition, playerPosition) < 500)
                {
                    if (thisPosition.Y > playerPosition.Y)
                    {
                        deltaY++;
                    }
                    if (thisPosition.Y < playerPosition.Y)
                    {
                        deltaY--;
                    }
                    if (thisPosition.X > playerPosition.X)
                    {
                        deltaX++;
                    }
                    if (thisPosition.X < playerPosition.X)
                    {
                        deltaX--;
                    }
                }
                else
                {
                    vector = Vector2.Zero;
                    return;
                }
            }
            else
            {
                if (thisPosition.Y > playerPosition.Y)
                {
                    deltaY--;
                }
                if (thisPosition.Y < playerPosition.Y)
                {
                    deltaY++;
                }
                if (thisPosition.X > playerPosition.X)
                {
                    deltaX--;
                }
                if (thisPosition.X < playerPosition.X)
                {
                    deltaX++;
                }
            }

            if (Math.Abs(thisPosition.Y - playerPosition.Y) < 5)
            {
                deltaY = 0;
            }

            if (Math.Abs(thisPosition.X - playerPosition.X) < 5)
            {
                deltaX = 0;
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
