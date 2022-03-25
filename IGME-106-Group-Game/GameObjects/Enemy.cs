using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IGME106GroupGame.GameObjects
{
    class Enemy : GameObject, IEntity
    {
        //Fields
        private int health;

        //Properties
        public int Health { get => Health; set => Health = value; }

        //Constructor
        public Enemy (Texture2D sprite, Vector2 startPos) : 
            base(sprite, startPos)
        {
            //not done yet
        }
    }
}
