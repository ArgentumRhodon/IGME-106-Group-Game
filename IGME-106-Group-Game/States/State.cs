﻿using IGME106GroupGame.UI;
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
        protected MouseManager mouseManager;

        // Properties
        /// <summary>
        /// This property allows the easy transitioning between states by storing the next state
        /// </summary>
        public State NextState
        {
            get => nextState;
            set => nextState = value;
        }

        public MouseManager MouseManager => mouseManager;

        public Game1 Game => game;

        // Constructor
        /// <summary>
        /// This constructor will instantiate a new State object
        /// </summary>
        /// <param name="game"></param>
        public State(Game1 game)
        {
            // userInterfaces = new List<UI>();
            this.game = game;
            mouseManager = new MouseManager();
        }

        // Methods
        /// <summary>
        /// This method will update the state
        /// </summary>
        public virtual void Update()
        {
            if(nextState != null)
            {
                game.State = nextState;
            }

            mouseManager.Update(this);
            ui.Update(this, mouseManager);
        }

        /// <summary>
        /// This method will draw the state
        /// </summary>
        /// <param name="_spriteBatch"></param>
        public virtual void Draw(SpriteBatch _spriteBatch, GraphicsDevice gd)
        {
            ui.Draw(_spriteBatch);
        }
    }
}
