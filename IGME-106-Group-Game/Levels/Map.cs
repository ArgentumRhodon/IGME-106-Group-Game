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

        // Tile sprites
        private Texture2D[] cornerSprites;
        private Texture2D[] wallSprites;
        private Texture2D floorSprite;
        private Texture2D baseSprite;

        // Tile information
        private const int TileHeight = 18;
        private const int TileWidth = 32;
        private const int TileSize = 60;

        // Constructor
        public Map(ContentManager content, string filePath)
        {
            LoadContent(content);
            this.filePath = filePath;
            InitializeMap();
        }

        private void LoadContent(ContentManager content)
        {
            cornerSprites = new Texture2D[4];
            string[] cornerImages= Directory.GetFiles("content\\corner");
            for(int i = 0; i < cornerImages.Length; i++)
            {
                string filePath = cornerImages[i].Remove(0, "content\\".Length).Substring(0, cornerImages[i].Length - 4);
                cornerSprites[i] = content.Load<Texture2D>(filePath);
            }

            wallSprites = new Texture2D[4];
            string[] wallImages = Directory.GetFiles("content\\wall");
            for (int i = 0; i < wallImages.Length; i++)
            {
                cornerSprites[i] = content.Load<Texture2D>(wallImages[i].Remove(0, "content\\".Length).Remove(wallImages[i].Length - 3, wallImages[i].Length));
            }

            floorSprite = content.Load<Texture2D>("floor");
            baseSprite = content.Load<Texture2D>("base");
        }

        // Methods
        private void InitializeMap()
        {
            tiles = new Tile[TileHeight, TileWidth];
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
                LoadTiles(streamReader);
            }
            catch(IOException ex)
            {
                throw new Exception("Couldn't read from file " + filePath);
            }
            finally
            {
                streamReader.Close();
            }
        }

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
         * 1 -> top right corner
         * 2 -> top left corner
         * 3 -> bottom right corner
         * 4 -> bottom left corner
         * 
         * A -> north wall
         * B -> east wall
         * C -> south wall
         * D -> west wall
         * 
         * - -> floor
         */
        private Texture2D GetTileSprite(char tileRepresentative)
        {
            switch (tileRepresentative)
            {
                case '1':
                    return cornerSprites[3];
                case '2':
                    return cornerSprites[2];
                case '3':
                    return cornerSprites[1];
                case '4':
                    return cornerSprites[0];
                case 'A':
                    return wallSprites[1];
                case 'B':
                    return wallSprites[0];
                case 'C':
                    return wallSprites[2];
                case 'D':
                    return wallSprites[3];
                case '-':
                    return floorSprite;
                default:
                    return baseSprite;
            }
        }
    }
}
