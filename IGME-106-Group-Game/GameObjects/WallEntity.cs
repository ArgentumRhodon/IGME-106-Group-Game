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
        public WallEntity(Texture2D sprite, Vector2 startingPosition) : base(sprite, startingPosition) { }

        // Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public override void HandleCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
