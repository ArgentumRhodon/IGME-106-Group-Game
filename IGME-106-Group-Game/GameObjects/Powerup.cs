using System;
using IGME106GroupGame.GameObjects;
using IGME106GroupGame.MovementAndAI;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.States;

namespace IGME106GroupGame.GameObjects
{
    public class Powerup : GameObject, IPickup
    {
        protected bool isCollected;

        public bool IsCollected { get => isCollected; set => isCollected = value; }
        //Constructor
        public Powerup(Texture2D sprite, Vector2 position) :
            base(sprite, position)
        {
            movement = new PickupMovement(0);
            isCollected = false;
        }

        public override void HandleCollision(GameObject other)
        {
            if(other is Player p)
            {
                OnPickup(p);
            }
        }

        //Methods
        public virtual void OnPickup(Player player)
        {
            isCollected = true;
        }
    }
}
