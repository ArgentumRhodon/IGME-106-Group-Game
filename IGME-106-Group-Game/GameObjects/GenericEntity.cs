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
    /*
     * This is an example class to follow for player, enemy, and projectile.
     * I created one in GameState for testing in the game play. It works.
     */
    class GenericEntity : GameObject, IEntity
    {
        // Fields
        private int health;

        // Properties
        public int Health
        {
            get => health; 
            set => health = value;
        }

        // Constructor
        public GenericEntity(Texture2D sprite, Vector2 startingPosition)
            : base(sprite, startingPosition)
        {
            // Starts with a movement speed of 7 pixels per update with input
            movement = new Movement(7);
        }
    }
}
