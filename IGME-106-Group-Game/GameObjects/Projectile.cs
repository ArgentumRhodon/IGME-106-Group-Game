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

        //Properties
        public int Damage { get => damage; set => damage = value; }
        //health is the bullet's pierce
        public int Health { get => health; set => health = value; }
        //public int Speed

        //Constructor
        public Projectile (Texture2D sprite, Vector2 startPos) :
            base(sprite, startPos)
        {
            //not finished yet but leavin this for the sake of pushing
        }

    }
}
