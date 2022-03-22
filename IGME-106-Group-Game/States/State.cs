using IGME_106_Group_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.States
{
    public abstract class State
    {
        // Fields
        // protected List<UI> userInterfaces;
        protected State nextState;
        protected Game1 game;

        // Constructor
        public State(Game1 game)
        {
            // userInterfaces = new List<UI>();
            this.game = game;
        }

        // Methods
        public virtual void Update()
        {
            if(nextState != null)
            {
                game.SetState(nextState);
            }
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
