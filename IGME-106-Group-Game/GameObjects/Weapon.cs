using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    class Weapon : GameObject, IPickup
    {
        //Fields
        private Projectile projectile;
        private int fireRate;

        //Properties
        public Projectile AmmoType { get => projectile; set => projectile = value; }

        //Constructor
        public Weapon (Texture2D sprite, Projectile proj, int fr) :
            base(sprite, new Vector2())
        {
            projectile = proj;
            fireRate = fr;
        }

        //Methods
        public void OnPickup()
        {

        }

        public void Fire()
        {

        }

        public override void HandleCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
