using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.Levels
{
    class Level
    {
        // Fields
        // private List<GameObject> objects;
        private List<Map> rooms;

        // Constructor
        public Level()
        {

        }
        
        // Methods
        public void Update()
        {
            //foreach(GameObject gameObject in objects)
            //{
            //    gameObject.Update();
            //}
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach(Map room in rooms)
            {
                room.Draw(_spriteBatch);
            }
            //foreach(GameObject gameObject in objects)
            //{
            //    gameObject.Draw(_spriteBatch);
            //}
        }
    }
}
