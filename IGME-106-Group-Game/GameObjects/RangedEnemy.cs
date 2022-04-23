using System;
using System.Collections.Generic;
using System.Text;
using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using IGME106GroupGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    public class RangedEnemy: Enemy
    {
        public Random random;
        //Fields
        Random random;
        private HealthBar healthBar;

        private int health;
        private bool collidedWithOtherEnemy = false;
        private Vector2 collisionPosition;
        private int fireDelay;

        //Properties
        public int FireDelay { get { return fireDelay; } set { fireDelay = value; } }

        public HealthBar HealthBar => healthBar;

        //Constructor
        public RangedEnemy (Texture2D sprite, Vector2 startPos, Player player) : 
            base(sprite, startPos, player)
        {
            movement = new RangedEnemyMovement(5, this, player);
            health = 4;
            healthBar = new HealthBar(this, health);
            random = new Random();
            fireDelay = random.Next(45, 90);
        }

        // Methods
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            base.Update(gameObjectHandler);
            fireDelay--;
            //-1 so there's a frame where it actually equals 0 for the handler to check
            if (fireDelay <= -1)
            {
                fireDelay = random.Next(45, 90);
            }
        }

        public override void HandleCollision(GameObject other)
        {
            base.HandleCollision(other);
        }
    }
}
