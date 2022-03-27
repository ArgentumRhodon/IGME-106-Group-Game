using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IGME106GroupGame.MovementAndAI;

namespace IGME106GroupGame.GameObjects
{
    class Player : GameObject, IEntity
    {
        //Fields
        private int health;

        //Properties
        public int Health { get => health; set => health = value; }

        //Constructor
        public Player(Texture2D sprite, Vector2 startPos) :
            base(sprite, startPos)
        {
            movement = new Movement(9);
            health = 10;
        }
    }
}
