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
    abstract class GameObject
    {
        // Fields
        protected Texture2D sprite;
        protected Vector2 position;
        protected Movement movement;

        //Properties
        public Texture2D Sprite { get => sprite; set => sprite = value; }
        public Vector2 Position { get => position; set => position = value; }
        public Movement Move { get => movement; set => movement = value; }

        // Constructor
        public GameObject(Texture2D sprite, Vector2 startingPosition)
        {
            this.sprite = sprite;
            this.position = startingPosition;
        }

        // Methods

        /// <summary>
        /// Takes a target position and updates the movement of the object with said position
        /// </summary>
        /// <param name="targetPosition">The target position of the object</param>
        public virtual void Update(Vector2 targetPosition = default(Vector2))
        {
            //move the object by the target position minus the current position
            //if a position is given
            if (targetPosition != default(Vector2))
            {
                movement.Update(targetPosition - position);
            }
            //if a position isn't given update with the default vector
            //which is a zero vector so no movement
            else
            {
                movement.Update();
            }
            position += movement.Vector;
        }


        /// <summary>
        /// Draws the object to the screen 
        /// </summary>
        /// <param name="_spriteBatch">the spritebatch with which to draw the object (_spriteBatch)</param>
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
