using IGME106GroupGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace IGME106GroupGame.Levels
{
    class Map
    {
        // Fields
        private Tile[,] tiles;
        private string filePath;

        // Tile information
        private const int TileHeight = 18;
        private const int TileWidth = 32;
        private const int TileSize = 60;

        // Constructor
        /// <summary>
        /// This constructor will instantiate a new Map
        /// </summary>
        /// <param name="content">The Content Manager</param>
        /// <param name="filePath">The file path of the map</param>
        public Map(string filePath)
        {
            this.filePath = filePath;
            InitializeMap();
        }

        // Methods
        /// <summary>
        /// This method will initialize the map
        /// </summary>
        private void InitializeMap()
        {
            tiles = new Tile[TileHeight, TileWidth];
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
                LoadTiles(streamReader);
            }
            catch(IOException)
            {
                throw new Exception("Couldn't read from file " + filePath);
            }
            finally
            {
                streamReader.Close();
            }
        }

        /// <summary>
        /// This method will load the tiles from the level file
        /// </summary>
        /// <param name="streamReader"></param>
        private void LoadTiles(StreamReader streamReader)
        {
            for(int i = 0; i < TileHeight; i++)
            {
                for(int j = 0; j < TileWidth; j++)
                {
                    tiles[i, j] = new Tile(GetTileSprite((char)streamReader.Read()));
                }
                streamReader.ReadLine();
            }
        }

        /// <summary>
        /// This method will draw the map to the screen
        /// </summary>
        /// <param name="_spriteBatch"></param>
        public void Draw(SpriteBatch _spriteBatch)
        {
            for(int i = 0; i < TileHeight; i++)
            {
                for(int j = 0; j < TileWidth; j++)
                {
                    _spriteBatch.Draw(tiles[i,j].Sprite, new Vector2(j * TileSize, i * TileSize), Color.White);
                }
            }
        }

        /*
         * 1 -> top left corner
         * 2 -> top right corner
         * 3 -> bottom left corner
         * 4 -> bottom right corner
         * 
         * A -> north wall
         * B -> east wall
         * C -> south wall
         * D -> west wall
         * 
         * - -> floor
         */
        /// <summary>
        /// This method will get the tile sprites of each coordinate of the map (see key above for conversion)
        /// </summary>
        /// <param name="tileRepresentative">The character representing the tile</param>
        /// <returns></returns>
        private Texture2D GetTileSprite(char tileRepresentative)
        {
            switch (tileRepresentative)
            {
                case '1':
                    return Assets.Textures["topLeft"];
                case '2':
                    return Assets.Textures["topRight"];
                case '3':
                    return Assets.Textures["bottomLeft"];
                case '4':
                    return Assets.Textures["bottomRight"];
                case 'A':
                    return Assets.Textures["north"];
                case 'B':
                    return Assets.Textures["east"];
                case 'C':
                    return Assets.Textures["south"];
                case 'D':
                    return Assets.Textures["west"];
                case '-':
                    return Assets.Textures["floor"];
                default:
                    return Assets.Textures["default"];
            }
        }
    }
}
