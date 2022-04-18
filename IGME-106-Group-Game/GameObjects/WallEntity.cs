using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.GameObjects
{
    class WallEntity : IEntity
    {
        // Fields
        private Vector2 pos;

        public int Health { get => int.MaxValue; }

        public Rectangle CollisionBox => new Rectangle((int)pos.X, (int)pos.Y, 60, 60);

        // Constructors
        /// <summary>
        /// This constructor will create a new WallEntity
        /// </summary>
        /// <param name="pos">The position of the wall entity</param>
        public WallEntity(Vector2 pos)
        {
            this.pos = pos;
        }
    }
}
