using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGME106GroupGame.Levels
{
    class Map
    {
        // Fields
        private Tile[][] tiles;

        // Constructor
        public Map()
        {

        }

        // Methods
        public void Draw(SpriteBatch _spriteBatch)
        {
            int i = 0;
            int j = 0;
            foreach(Tile[] tileArray in tiles)
            {
                foreach(Tile tile in tileArray)
                {
                    tile.Draw(_spriteBatch, new Vector2(i*64, j*64));
                    j++;
                }
                i++;
            }
        }
    }
}
