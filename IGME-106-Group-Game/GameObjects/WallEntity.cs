using IGME106GroupGame.MovementAndAI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.GameObjects
{
    class WallEntity : GameObject
    {
        // Constructors
        /// <summary>
        /// This constructor will create a new WallEntity
        /// </summary>
        public WallEntity(Texture2D sprite, Vector2 startingPosition) : base(sprite, startingPosition) { movement = new Movement(0); }

        // Methods
        /// <summary>
        /// Because WallEntity doesn't actually need to handle collisions itself, just return
        /// </summary>
        /// <param name="other">The other object to check against</param>
        public override void HandleCollision(GameObject other)
        {
            return;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            
        }
    }
}
