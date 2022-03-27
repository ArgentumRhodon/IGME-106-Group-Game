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
        public virtual void Update(Vector2 targetPosition = default(Vector2))
        {
            if (targetPosition != default(Vector2))
            {
                movement.Update(targetPosition - position);
            }
            else
            {
                movement.Update();
            }
            position += movement.Vector;
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
