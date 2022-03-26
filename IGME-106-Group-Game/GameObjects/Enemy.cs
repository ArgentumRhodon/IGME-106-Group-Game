using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    class Enemy : GameObject, IEntity
    {
        //Fields
        private int health;
        private Rectangle rect;

        //Properties
        public int Health { get => Health; set => Health = value; }

        //Constructor
        public Enemy (Texture2D sprite, Vector2 startPos) : 
            base(sprite, startPos)
        {
            //the projectile's dimensions
            rect.X = (int)startPos.X;
            rect.Y = (int)startPos.Y;
            //have to convert to int to set them equal
            rect.Width = sprite.Width;
            rect.Height = sprite.Height;
        }

        //Methods
        public void TakeDamage(Projectile projectile)
        {
            if (projectile.PosRect.Intersects(rect))
            {
                health -= projectile.Damage;
                projectile.Health--;
            }
        }
    }
}
