using System;
using System.Collections.Generic;
using System.Text;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    class Enemy : GameObject, IEntity
    {
        //Fields
        private int health;
        private bool collidedWithOtherEnemy = false;
        private Vector2 collisionPosition;
        //private int fireDelay;

        //Properties
        public int Health { get => health; set => health = value; }

        //Constructor
        public Enemy (Texture2D sprite, Vector2 startPos, Vector2 playerPosition) : 
            base(sprite, startPos)
        {
            movement = new EnemyMovement(6);
            health = 1;
            //fireDelay = rng.Next(45, 315);
        }

        // Methods
        public void Update(GameObjectHandler gameObjectHandler, Vector2 enemyPosition, Vector2 playerPosition)
        {
            ((EnemyMovement)movement).Update(enemyPosition, playerPosition);
            HandleCollisions(gameObjectHandler);
            if(collidedWithOtherEnemy)
            {
                Vector2 direction = position - collisionPosition;
                if (direction.Length() < 100)
                {
                    direction = position - collisionPosition;
                    direction.Normalize();
                    movement.Vector = direction * (5 / direction.Length());
                }
                else
                {
                    collidedWithOtherEnemy = false;
                    collisionPosition = Vector2.Zero;
                }
            }
            position += movement.Vector;
            //fireDelay--;
            //-1 so there's a frame where it actually equals 0 for the handler to check
            //if(fireDelay <= -1)
            //{
            //    fireDelay = rng.Next(45, 315);
            //}
        }

        public override void HandleCollision(GameObject other)
        {
            if(other is Projectile)
            {
                health--;
            }

            if(other is Enemy)
            {
                collidedWithOtherEnemy = true;
                collisionPosition = other.Position;
            }
        }
    }
}
