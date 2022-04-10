using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGME106GroupGame.GameObjects;

namespace IGME106GroupGame.MovementAndAI
{
    public abstract class Movement
    {
        // Fields
        protected Vector2 vector;
        protected float speed;

        // Properties
        public Vector2 Vector
        {
            get => vector;
            set => vector = value;
        }

        // Constructor
        public Movement(float speed)
        {
            this.speed = speed;
            this.vector = new Vector2(0, 0);
        }

        // Methods
        public abstract void Update();

        public void Stop(bool stopX, bool stopY)
        {
            vector = new Vector2
            (
                stopX ? 0 : vector.X,
                stopY ? 0 : vector.Y
            );
        }

    }
}
