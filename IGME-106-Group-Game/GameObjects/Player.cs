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

        public void ActivateIFrames(int numFrames)
        {
            IFrames = numFrames;
        }

        public override void Update(Vector2 targetPosition = default)
        {
            base.Update(targetPosition);

            iFrames--;
        }
    }
}
