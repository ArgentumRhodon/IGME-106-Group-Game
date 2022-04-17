﻿using IGME106GroupGame.UI;
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
        private Assets assets;

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
        /// <summary>
        /// This constructor will instantiate a new Map
        /// </summary>
        /// <param name="content">The Content Manager</param>
        /// <param name="filePath">The file path of the map</param>
        public Map(Assets assets, string filePath)
        {
            this.filePath = filePath;
            this.assets = assets;
            InitializeMap();
        }

        // Methods
        /// <summary>
        /// This method loads content from the wall and corner folders under \Content\
        /// </summary>
        /// <param name="content"></param>
        private void LoadContent(ContentManager content)
        {
            cornerSprites = new Texture2D[4];
            string[] cornerImages= Directory.GetFiles("content\\corner");
            for(int i = 0; i < cornerImages.Length; i++)
            {
                string filePath = cornerImages[i].Remove(0, "content\\".Length);
                filePath = filePath.Substring(0, filePath.Length - 4);
                cornerSprites[i] = content.Load<Texture2D>(filePath);
            }

            wallSprites = new Texture2D[4];
            string[] wallImages = Directory.GetFiles("content\\wall");
            for (int i = 0; i < wallImages.Length; i++)
            {
                string filePath = wallImages[i].Remove(0, "content\\".Length);
                filePath = filePath.Substring(0, filePath.Length - 4);
                wallSprites[i] = content.Load<Texture2D>(filePath);
            }

            floorSprite = content.Load<Texture2D>("floor");
            baseSprite = content.Load<Texture2D>("base");
        }

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
                    return assets.Get("topRight");
                case '2':
                    return assets.Get("topLeft");
                case '3':
                    return assets.Get("bottomRight");
                case '4':
                    return assets.Get("bottomLeft");
                case 'A':
                    return assets.Get("north");
                case 'B':
                    return assets.Get("east");
                case 'C':
                    return assets.Get("south");
                case 'D':
                    return assets.Get("west");
                case '-':
                    return assets.Get("floor");
                default:
                    return assets.Get("default");
            }
        }
    }
}
