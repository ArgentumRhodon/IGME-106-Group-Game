using System;
using System.Collections.Generic;
using System.Text;
using IGME106GroupGame.MovementAndAI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    class Enemy : GameObject, IEntity
    {
        //Fields
        private int health;
        //private int fireDelay;

        //Properties
        public int Health { get => health; set => health = value; }
        public Rectangle CollisionBox
        { 
            get => new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }
        //public int FireDelay { get => fireDelay; set => fireDelay = value; }

        //Constructor
        public Enemy (Texture2D sprite, Vector2 startPos, Vector2 playerPosition) : 
            base(sprite, startPos)
        {
            movement = new EnemyMovement(6);
            health = 1;
            //fireDelay = rng.Next(45, 315);
        }

        // Methods
        public void Update(Vector2 enemyPosition, Vector2 playerPosition)
        {
            ((EnemyMovement)movement).Update(enemyPosition, playerPosition, new Vector2(sprite.Width, sprite.Height));
            position += movement.Vector;
            //fireDelay--;
            //-1 so there's a frame where it actually equals 0 for the handler to check
            //if(fireDelay <= -1)
            //{
            //    fireDelay = rng.Next(45, 315);
            //}
        }
    }
}
