using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IGME106GroupGame
{
    class Movement
    {
        //Fields
        private int speed;
        private Vector2 moveVector;

        //Constructor
        public Movement(int spe)
        {
            speed = spe;
            moveVector = new Vector2();
        }

        //Methods
        public void Update(GameObject target)
        {

        }
        public void Update(Vector2 direction)
        {

        }
    }
}
