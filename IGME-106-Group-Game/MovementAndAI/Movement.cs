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
        public Vector2 Vector => vector;
        
        // Constructor
        public Movement(float speed)
        {
            this.speed = speed;
            this.vector = new Vector2(0, 0);
        }

        public abstract void Update();
    }
}
