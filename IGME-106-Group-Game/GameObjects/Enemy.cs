using System;
using System.Collections.Generic;
using System.Text;
using IGME106GroupGame.MovementAndAI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    class Enemy : GameObject, IEntity
    {
        //Fields
        private int health;

        //Properties
        public int Health { get => health; set => health = value; }

        //Constructor
        public Enemy (Texture2D sprite, Vector2 startPos, Vector2 playerPosition) : 
            base(sprite, startPos)
        {
            movement = new EnemyMovement(6);
            health = 1;
        }

        // Methods
        public void Update(Vector2 enemyPosition, Vector2 playerPosition)
        {
            ((EnemyMovement)movement).Update(enemyPosition, playerPosition);
            position += movement.Vector;
        }

        public override void HandleCollision(GameObject other)
        {
            if(other is Projectile)
            {
                health--;
            }

            if(other is Player)
            {
                movement.CanMoveX = !WillCollideX(other);
                movement.CanMoveY = !WillCollideY(other);
            }
        }
    }
}
