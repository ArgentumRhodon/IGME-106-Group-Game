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
        private Texture2D baseTileSprite;
        private Texture2D wallTileSprite;
        private Texture2D floorTileSprite;

        // Tile information
        private const int TileHeight = 18;
        private const int TileWidth = 32;
        private const int TileSize = 60;

        // Test

        // Constructor
        public Map(ContentManager content, string filePath)
        {
            baseTileSprite = content.Load<Texture2D>("base");
            wallTileSprite = content.Load<Texture2D>("wall");
            floorTileSprite = content.Load<Texture2D>("floor");
            this.filePath = filePath;
            InitializeMap();
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

        private Texture2D GetTileSprite(char tileRepresentative)
        {
            switch (tileRepresentative)
            {
                case '-':
                    return baseTileSprite;
                case 'W':
                    return wallTileSprite;
                case 'F':
                    return floorTileSprite;
                default:
                    return baseTileSprite;
            }
        }
    }
}
