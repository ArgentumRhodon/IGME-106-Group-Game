using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.MovementAndAI;

namespace IGME106GroupGame.GameObjects
{
    class Player : GameObject, IEntity
    {
        //Fields
        private int health;
        private int iFrames;

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
        public Rectangle CollisionBox
        {
            get => new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        //Constructor
        public Player(Texture2D sprite, Vector2 startPos) :
            base(sprite, startPos)
        {
            movement = new Movement(9);
            health = 6;
            iFrames = 0;
        }

        /// <summary>
        /// Activates invincibility frames for the player
        /// </summary>
        /// <param name="numFrames">The number of invincibility frames to give to the player</param>
        public void ActivateIFrames(int numFrames)
        {
            IFrames = numFrames;
        }

        /// <summary>
        /// Updates the player's position and gets rid of i-frames gradually once they are given
        /// </summary>
        /// <param name="targetPosition">The new position for the player</param>
        public override void Update(Vector2 targetPosition = default)
        {
            base.Update(targetPosition);

            iFrames--;
        }
    }
}
