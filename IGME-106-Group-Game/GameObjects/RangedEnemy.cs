using System;
using System.Collections.Generic;
using System.Text;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    public class RangedEnemy: Enemy
    {
        //Fields
        //private int fireDelay;

        //Properties


        //Constructor
        public RangedEnemy (Texture2D sprite, Vector2 startPos, Player player) : 
            base(sprite, startPos, player)
        {
            movement = new RangedEnemyMovement(6, this, player);
            health = 1;
            //fireDelay = rng.Next(45, 315);
        }

        // Methods
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            base.Update(gameObjectHandler);
            //fireDelay--;
            //-1 so there's a frame where it actually equals 0 for the handler to check
            //if(fireDelay <= -1)
            //{
            //    fireDelay = rng.Next(45, 315);
            //}
        }

        public override void HandleCollision(GameObject other)
        {
            base.HandleCollision(other);
        }
    }
}
