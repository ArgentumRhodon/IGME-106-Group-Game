using IGME106GroupGame.GameObjects;
using IGME106GroupGame.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.States
{
    class GameState : State
    {
        // Fields
        // private Player player;
        private Level level;
        private GenericEntity genericEntity;


        // Constructor
        public GameState(Game1 game)
            : base(game)
        {
            level = new Level(game.Content);
            genericEntity = new GenericEntity(game.Content.Load<Texture2D>("base"), new Vector2(300, 300));
        }

        // Methods
        public override void Update()
        {
            base.Update();

            //GameState logic
            level.Update();
            genericEntity.Update();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);

            // GameState rendering
            level.Draw(_spriteBatch);
            genericEntity.Draw(_spriteBatch);
        }
    }
}
