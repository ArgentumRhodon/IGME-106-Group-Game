using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using IGME106GroupGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.GameObjects
{
    public class MeleeEnemy : Enemy
    {
        //Fields
        private int health;
        private HealthBar healthBar;
        private bool collidedWithOtherEnemy = false;
        private Vector2 collisionPosition;

        //Properties
        public int Health { get => health; set => health = value; }

        public HealthBar HealthBar => healthBar;

        //Constructor
        public MeleeEnemy(Texture2D sprite, Vector2 startPos, Player player) :
            base(sprite, startPos, player)
        {
            movement = new MeleeEnemyMovement(5, this, player);
            health = 2;
            healthBar = new HealthBar(this, health);
        }

        // Methods
        public override void Update(GameObjectHandler gameObjectHandler)
        {
            position += movement.Vector;
        }

        public override void HandleCollision(GameObject other)
        {
            base.HandleCollision(other);
        }
    }
}
