﻿using IGME106GroupGame.MovementAndAI;
using IGME106GroupGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.GameObjects
{
    public abstract class GameObject
    {
        // Fields
        protected Texture2D sprite;
        protected Vector2 position;
        protected Movement movement;

        //Properties
        public Texture2D Sprite { get => sprite; set => sprite = value; }
        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Center { get => new Vector2(position.X + (sprite.Width / 2), position.Y + (sprite.Height / 2));}
        public Movement Movement => movement;
        public Rectangle NextCollisionBox
        {
            get => new Rectangle((int)position.X + (int)movement.Vector.X, (int)position.Y + (int)movement.Vector.Y, sprite.Width, sprite.Height);
        }
        public Rectangle CollisionBox
        {
            get => new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

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
        public virtual void Update(GameObjectHandler gameObjectHandler)
        {
            movement.Update();
            HandleCollisions(gameObjectHandler);
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

        protected void HandleCollisions(GameObjectHandler objectHandler)
        {
            foreach (GameObject collidingObject in objectHandler.GetCollidingObjects(this))
            {
                HandleCollision(collidingObject);
            }
        }

        public abstract void HandleCollision(GameObject other);

        #region StopLogic
        public bool WillCollideX(GameObject other)
        {
            Rectangle NextCollisionBoxInX = new Rectangle
            (
                (int)position.X + (int)movement.Vector.X,
                (int)position.Y,
                sprite.Width,
                sprite.Height
            );

            return NextCollisionBoxInX.Intersects(other.NextCollisionBox);
        }

        public bool WillCollideY(GameObject other)
        {
            Rectangle NextCollisionBoxInY = new Rectangle
            (
                (int)position.X,
                (int)position.Y + (int)movement.Vector.Y,
                sprite.Width,
                sprite.Height
            );

            return NextCollisionBoxInY.Intersects(other.NextCollisionBox);
        }
        #endregion
    }
}
