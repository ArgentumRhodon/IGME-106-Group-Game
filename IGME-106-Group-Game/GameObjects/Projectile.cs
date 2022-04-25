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
    public class Projectile : GameObject, IEntity
    {
        //Fields
        //private bool canRicochet;
        //private int framesActive;
        private int damage;
        private int health;
        private GameObject currentEnemy;
        private bool isEnemyProjectile;

        //Properties
        public int Damage { get => damage; set => damage = value; }
        //made a separator for the enemy's projectiles
        public bool IsEnemyProjectile { get => isEnemyProjectile; set => isEnemyProjectile = value; }
        //health is the bullet's pierce
        public int Health { get => health; set => health = value; }
        public GameObject CurrentEnemy { get => currentEnemy; set => currentEnemy = value; }

        public HealthBar HealthBar => throw new NotImplementedException();

        //Constructor
        public Projectile (Texture2D sprite, Vector2 p_1, Vector2 p_2, bool isEnemyProjectile, float speed, int health, int damage) :
            base(sprite, p_1)
        {
            this.isEnemyProjectile = isEnemyProjectile;
            movement = new ProjectileMovement(p_1, p_2, speed);
            this.health = health;
            this.damage = damage;
        }

        public override void HandleCollision(GameObject other)
        {
            if(other is Enemy && (Enemy)other != currentEnemy && !IsEnemyProjectile)
            {
                currentEnemy = (Enemy)other;
                health--;
            }

            if (other is WallCollider)
            {
                health = 0;
            }
        }
    }
}
