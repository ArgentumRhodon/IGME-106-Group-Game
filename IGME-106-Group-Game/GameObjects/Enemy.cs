using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    public class Enemy : GameObject, IEntity
    {
        //Fields
        private int health;
        //private int fireDelay;

        //Properties
        public int Health { get => health; set => health = value; }
        public Rectangle CollisionBox
        { 
            get => new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }
        //public int FireDelay { get => fireDelay; set => fireDelay = value; }

        //Constructor
        public Enemy(Texture2D sprite, Vector2 startPos, Player player) :
            base(sprite, startPos)
        {
            movement = new EnemyMovement(6, this, player);
            health = 1;
        }

        // Methods
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            movement.Update();
            HandleCollisions(gameObjectHandler);

            if (collidedWithOtherEnemy)
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
        }

        public override void HandleCollision(GameObject other)
        {
            if (other is Projectile && !((Projectile)other).IsEnemyProjectile)
            {
                health--;
            }

            if (other is IEntity && !(other is Projectile))
            {
                collidedWithOtherEnemy = true;
                collisionPosition = other.Position;
            }
        }
    }
}
