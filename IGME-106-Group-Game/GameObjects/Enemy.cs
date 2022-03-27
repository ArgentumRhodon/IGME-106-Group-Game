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

        //Properties
        public int Health { get => health; set => health = value; }
        public Rectangle CollisionBox
        { 
            get => new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        //Constructor
        public Enemy (Texture2D sprite, Vector2 startPos) : 
            base(sprite, startPos)
        {
            movement = new Movement(1);
        }

        //Methods
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(sprite, position, Color.Red);
        }
    }
}
