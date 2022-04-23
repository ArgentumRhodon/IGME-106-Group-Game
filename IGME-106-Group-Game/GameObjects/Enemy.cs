using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.UI;

namespace IGME106GroupGame.GameObjects
{
    public class Enemy : GameObject, IEntity
    {
        //Fields
        protected int health;
        protected HealthBar healthBar;
        protected bool collidedWithOtherEnemy = false;
        protected Vector2 collisionPosition;

        //Properties
        public int Health { get => health; set => health = value; }
        public HealthBar HealthBar { get => healthBar; set => healthBar = value; }

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
