using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;

namespace IGME106GroupGame.GameObjects
{
    class Player : GameObject, IEntity
    {
        //Fields
        private int health;
        private int iFrames;
        private bool isInvincible;

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

        //Constructor
        public Player(Texture2D sprite, Vector2 startPos, bool isInvincible) :
            base(sprite, startPos)
        {
            this.isInvincible = isInvincible;
            movement = new PlayerMovement(9);
            health = 6;
            iFrames = 0;
        }

        /// <summary>
        /// Updates the player's position and gets rid of i-frames gradually once they are given
        /// </summary>
        /// <param name="targetPosition">The new position for the player</param>
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            ((PlayerMovement)movement).Update(position, new Vector2(sprite.Width, sprite.Height));
            HandleCollisions(gameObjectHandler);
            position += movement.Vector;

            if(iFrames > 0)
            {
                iFrames--;
            }
        }

        public override void HandleCollision(GameObject other)
        {
            if(other is Enemy || (other is Projectile && ((Projectile)other).IsEnemyProjectile))
            {
                if(iFrames == 0 && !isInvincible)
                {
                    health--;
                    IFrames = 30;
                }
            }
        }
    }
}
