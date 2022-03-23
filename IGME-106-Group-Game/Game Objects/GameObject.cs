using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IGME106GroupGame
{
    class GameObject
    {
        //Fields
        protected Texture2D sprite;
        protected Vector2 position;
        protected Movement movement;

        //Methods
        public void Update()
        {

        }

        public void Draw (SpriteBatch sb)
        {
            sb.Draw(sprite, position, Color.White);
        }
    }
}
