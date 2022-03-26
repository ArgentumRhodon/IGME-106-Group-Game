using System;
using System.Collections.Generic;
using System.Text;
using IGME106GroupGame.MovementAndAI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    class Projectile : GameObject, IEntity
    {
        //Fields
        private int damage;
        private bool canRicochet;
        private int framesActive;
        private int health;
        private Rectangle rect;

        //Properties
        public int Damage { get => damage; set => damage = value; }
        //health is the bullet's pierce
        public int Health { get => health; set => health = value; }
        //public int Speed
        public Rectangle PosRect { get => rect; set => rect = value; }
        //shouuld only be a get unless one of the buffs is ricochet rounds or smth
        public bool CanRicochet { get => canRicochet; }
        public int FramesActive { get => framesActive; }

        //Constructor
        public Projectile (Texture2D sprite, Vector2 startPos) :
            base(sprite, startPos)
        {
            //the projectile's dimensions
            rect.X = (int)startPos.X;
            rect.Y = (int)startPos.Y;
            //have to convert to int to set them equal
            rect.Width = sprite.Width;
            rect.Height = sprite.Height;
        }



    }
}
