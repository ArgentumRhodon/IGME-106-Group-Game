﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;

namespace IGME106GroupGame.GameObjects
{
    public class Player : GameObject, IEntity
    {
        //Fields
        private int health;
        private int iFrames;
        private bool isInvincible;
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

        //Constructor
        public Player(Texture2D sprite, Vector2 startPos, bool isInvincible) :
            base(sprite, startPos)
        {
            movement = new PlayerMovement(8, this);
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
            if (other is RangedEnemy || other is MeleeEnemy || (other is Projectile && ((Projectile)other).IsEnemyProjectile))
            {
                if(iFrames == 0 && !isInvincible)
                {
                    health--;
                    IFrames = 30;
                }
            }

            if (other is WallEntity) // Finish this
            {
                collisionPosition = other.Position;
                Vector2 direction = position - collisionPosition;
                direction.Normalize();
                movement.Vector = direction * (5 / direction.Length());
            }
        }
    }
}
