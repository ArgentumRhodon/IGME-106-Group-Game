using IGME106GroupGame.UI;
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
        protected UserInterface ui;
        protected State nextState;
        protected Game1 game;

        // Properties
        public State NextState
        {
            get => nextState;
            set => nextState = value;
        }

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
                game.State = nextState;
            }

            ui.Update(this);
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            ui.Draw(_spriteBatch);
        }
    }
}
