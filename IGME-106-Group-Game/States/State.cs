using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.States
{
    abstract class State
    {
        // Fields
        // protected List<UI> userInterfaces;

        // Constructor
        public State()
        {
            // userInterfaces = new List<UI>();
        }

        // Methods
        public virtual void Update()
        {
            //foreach(UI ui in unserInterfaces)
            //{
            //    ui.Update();
            //}
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            //foreach(UI ui in userInterfaces)
            //{
            //    ui.Draw();
            //}
        }

    }
}
