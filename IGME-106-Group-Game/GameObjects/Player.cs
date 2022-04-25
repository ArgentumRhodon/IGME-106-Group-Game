using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using IGME106GroupGame.UI;

namespace IGME106GroupGame.GameObjects
{
    public class Player : GameObject, IEntity
    {
        //Fields
        private int health;
        private HealthBar healthBar;
        private int iFrames;
        private bool isInvincible;
        private int fireDelay;
        private Vector2 collisionPosition;

        //Properties
        public int Health { get => health; set => health = value; }
        public int IFrames
        {
            get => iFrames;
            set
            {
                if(iFrames > 0)
                {
                    return;
                }
                iFrames = value;
            }
        }
        public int FireDelay
        {
            get => fireDelay;
            set => fireDelay = value;
        }

        public HealthBar HealthBar => throw new NotImplementedException();

        //Constructor
        public Player(Texture2D sprite, Vector2 startPos, bool isInvincible) :
            base(sprite, startPos)
        {
            movement = new PlayerMovement(10, this);
            this.isInvincible = isInvincible;
            health = 6;
        }

        /// <summary>
        /// Updates the player's position and gets rid of i-frames gradually once they are given
        /// </summary>
        /// <param name="targetPosition">The new position for the player</param>
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            base.Update(gameObjectHandler);
            if(iFrames > 0)
            {
                iFrames--;
            }
            if(fireDelay > 0)
            {
                fireDelay--;
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            if(iFrames != 0)
            {
                _spriteBatch.Draw(sprite, position, Color.Red);
            }
            else
            {
                base.Draw(_spriteBatch);
            }
        }

        public override void HandleCollision(GameObject other)
        {
            if(other is RangedEnemy || other is MeleeEnemy || other is Boss || (other is Projectile && ((Projectile)other).IsEnemyProjectile))
            {
                if(iFrames == 0 && !isInvincible)
                {
                    health--;
                    IFrames = 30;
                }
            }

            if (other is WallEntity)
            {
                Vector2 direction = position - collisionPosition;
                direction.Normalize();
                
                if (direction.X != 0)
                {
                    direction.X = 0;
                }
                if (direction.Y != 0)
                {
                    direction.Y = 0;
                }

                movement.Vector = direction;
            }
        }
    }
}
