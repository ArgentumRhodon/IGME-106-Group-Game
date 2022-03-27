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
        public int Health { get => Health; set => Health = value; }
        public Rectangle CollisionBox { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //Constructor
        public Player(Texture2D sprite, Vector2 startPos) :
            base(sprite, startPos)
        {
            movement = new Movement(9);
        }
    }
}
