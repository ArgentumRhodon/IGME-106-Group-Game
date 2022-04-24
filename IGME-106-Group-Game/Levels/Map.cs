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
        private Assets assets;

        // Tile sprites
        private Texture2D[] cornerSprites;
        private Texture2D[] wallSprites;
        private Texture2D[] outCornerSprites;
        private Texture2D floorSprite;
        private Texture2D baseSprite;

        // Tile information
        private int TileHeight;
        private int TileWidth;
        private const int TileSize = 60;
        private int colorLevel;

        // Constructor
        /// <summary>
        /// This constructor will instantiate a new Map
        /// </summary>
        /// <param name="content">The Content Manager</param>
        /// <param name="filePath">The file path of the map</param>
        public Map(Assets assets)
        {
            this.assets = assets;
            InitializeMap();
        }

        // Methods
        /// <summary>
        /// This method loads content from the wall and corner folders under \Content\
        /// </summary>
        /// <param name="content"></param>
        private void LoadContent(ContentManager content) // Needs editing, add support for colors and outCorners and center wall
        {
            cornerSprites = new Texture2D[4];
            string[] cornerImages= Directory.GetFiles($"Content\\Tiles\\corner\\{colorLevel}\\");
            for(int i = 0; i < cornerImages.Length; i++)
            {
                string filePath = cornerImages[i].Remove(0, $"content\\Tiles\\{colorLevel}".Length);
                filePath = filePath.Substring(0, filePath.Length - 4);
                cornerSprites[i] = content.Load<Texture2D>(filePath);
            }

            outCornerSprites = new Texture2D[4];
            string[] outCornerImages = Directory.GetFiles($"Content\\Tiles\\outCorner\\{colorLevel}\\");
            for (int i = 0; i < outCornerImages.Length; i++)
            {
                string filePath = outCornerImages[i].Remove(0, $"content\\Tiles\\{colorLevel}".Length);
                filePath = filePath.Substring(0, filePath.Length - 4);
                outCornerSprites[i] = content.Load<Texture2D>(filePath);
            }

            wallSprites = new Texture2D[5];
            string[] wallImages = Directory.GetFiles($"Content\\Tiles\\wall\\{colorLevel}\\");
            for (int i = 0; i < wallImages.Length; i++)
            {
                string filePath = wallImages[i].Remove(0, $"Content\\Tiles\\{colorLevel}\\".Length);
                filePath = filePath.Substring(0, filePath.Length - 4);
                wallSprites[i] = content.Load<Texture2D>(filePath);
            }

            floorSprite = content.Load<Texture2D>($"Content\\Tiles\\{colorLevel}\\floor\\floor");
            baseSprite = content.Load<Texture2D>("base");
        }

        /// <summary>
        /// This method gets info about the level
        /// </summary>
        private void GetLevelInfo(StreamReader streamReader)
        {
            try
            {
                String[] info = streamReader.ReadLine().Split(',');
                TileWidth = int.Parse(info[0]);
                TileHeight = int.Parse(info[1]);
                colorLevel = int.Parse(info[2]);
            }
            catch (IOException)
            {
                throw new Exception("Couldn't read from file " + filePath);
            }
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
                GetLevelInfo(streamReader);
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
        /// This method will update the level (currently disabled or be needed at all lol)
        /// </summary>
        public void Update()
        {
            //foreach(GameObject gameObject in objects)
            //{
            //    gameObject.Update();
            //}
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
         * 5 -> inverted top left corner
         * 6 -> inverted top right corner
         * 7 -> inverted bottom left corner
         * 8 -> inverted bottom right corner
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
                    return assets.Get("topLeftWall");
                case '2':
                    return assets.Get("topRightWall");
                case '3':
                    return assets.Get("bottomLeftWall");
                case '4':
                    return assets.Get("bottomRightWall");
                case '5':
                    return assets.Get("topLeftWall");
                case '6':
                    return assets.Get("topRightWall");
                case '7':
                    return assets.Get("bottomLeftWall");
                case '8':
                    return assets.Get("bottomRightWall");
                case 'A':
                    return assets.Get("northWall");
                case 'B':
                    return assets.Get("eastWall");
                case 'C':
                    return assets.Get("southWall");
                case 'D':
                    return assets.Get("westWall");
                case '-':
                    return assets.Get("floor");
                default:
                    return assets.Get("base");
            }
        }

        /// <summary>
        /// This method returns a list of Vector2 with every coordinate with a wall tile
        /// </summary>
        /// <returns></returns>
        public List<Vector2> GetWallPositions()
        {
            List<Vector2> result = new List<Vector2>();

            // Iterate through tiles and get which ones are actually walls
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[x, y].Sprite != assets.Get("floor")) // Note: Needs to be updated if color levels implemented
                    {
                        result.Add(new Vector2(60 * x, 60 * y));
                    }
                }
            }

            return result;
        }
    }
}
