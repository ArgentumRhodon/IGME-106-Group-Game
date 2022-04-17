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
        //private bool canRicochet;
        //private int framesActive;
        private int damage;
        private int health;
        private Enemy currentEnemy;
        private bool isEnemyProj;

        //Properties
        public int Damage { get => damage; set => damage = value; }
        //made a separator for the enemy's projectiles
        public bool IsEnemyProjectile { get => isEnemyProj; set => isEnemyProj = value; }
        //health is the bullet's pierce
        public int Health { get => health; set => health = value; }
        public Enemy CurrentEnemy { get => currentEnemy; set => currentEnemy = value; }
        //public int Speed
        //public bool CanRicochet { get => canRicochet; }
        //public int FramesActive { get => framesActive; }

        //Constructor
        public Projectile (Texture2D sprite, Vector2 startPos, Vector2 mousePosition, bool isEnemProjectile, float speed) :
            base(sprite, startPos)
        {
            movement = new ProjectileMovement(speed, startPos, mousePosition);
            health = 2;
            damage = 1;
            isEnemyProj = isEnemProjectile;
        }

        public override void HandleCollision(GameObject other)
        {
            //since there are two types of enemies now i'd need to make two conditionals to check pierce properly for both
            if(other is RangedEnemy && other != currentEnemy && !IsEnemyProjectile)
            {
                currentEnemy = (RangedEnemy)other;
                health--;
            }
            //but currentEnemy's type is currently only the ranged one
            //and as it stands rn i can't cast between the enemy types for the sake of pierce checking
            //so it looks like i'll have to make an enemy class and have those two inherit from it
            //there's no telling what wacky hijinks will ensue but i'll try and make it work
            if (other is MeleeEnemy && other != currentEnemy && !IsEnemyProjectile)
            {
                currentEnemy = (MeleeEnemy)other;
                health--;
            }
        }
    }
}
