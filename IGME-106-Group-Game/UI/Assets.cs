using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI
{
    public static class Assets
    {
        // - Fields -
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        // - Property -
        /// <summary>
        /// A dictonary for all the game's textures
        /// </summary>
        public static Dictionary<string, Texture2D> Textures
        {
            get => textures;
        }

        public static Dictionary<string, SpriteFont> Fonts
        {
            get => fonts;
        }

        // - Methods -
        /// <summary>
        /// Loads all of the assets from all subfolders of content
        /// </summary>
        public static void LoadContent(ContentManager content)
        {
            LoadUIContent(content);
            LoadLevelContent(content);
            LoadGameObjectContent(content);
            LoadFontContent(content);
        }

        /// <summary>
        /// Loads all of the assets from the uiContent folder
        /// </summary>
        private static void LoadUIContent(ContentManager content)
        {
            DirectoryInfo[] uiDirectories = new DirectoryInfo(content.RootDirectory + "\\uiAssets").GetDirectories();
            foreach(DirectoryInfo uiDirectory in uiDirectories)
            {
                FileInfo[] fileInfos = uiDirectory.GetFiles("*.xnb");
                foreach (FileInfo file in fileInfos)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.Name);
                    Texture2D image = content.Load<Texture2D>("uiAssets\\" + uiDirectory.Name + "\\" + fileName);
                    textures.Add(fileName, image);
                }
            }
        }

        /// <summary>
        /// Loads all of the assets from the levelAssets folder
        /// </summary>
        /// <param name="content"></param>
        private static void LoadLevelContent(ContentManager content)
        {
            DirectoryInfo[] staurationLevels = new DirectoryInfo(content.RootDirectory + "\\Tiles").GetDirectories();
            foreach (DirectoryInfo staurationLevel in staurationLevels)
            {
                DirectoryInfo[] assetTypes = staurationLevel.GetDirectories();

                foreach(DirectoryInfo assetType in assetTypes)
                {
                    FileInfo[] fileInfos = assetType.GetFiles("*.xnb");

                    foreach(FileInfo file in fileInfos)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file.Name);
                        Texture2D image = content.Load<Texture2D>("Tiles\\" + staurationLevel.Name + "\\" + assetType.Name + "\\" + fileName);
                        textures.Add(fileName + staurationLevel.Name, image);
                    }
                }
            }
        }

        /// <summary>
        /// Loads all of the content from the gameObjects folder
        /// </summary>
        /// <param name="content"></param>
        private static void LoadGameObjectContent(ContentManager content)
        {
            DirectoryInfo dir = new DirectoryInfo(content.RootDirectory + "\\gameObjects");
            FileInfo[] fileInfos = dir.GetFiles();
            foreach (FileInfo file in fileInfos)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.Name);
                Texture2D image = content.Load<Texture2D>(dir.Name + "\\" + fileName);
                textures.Add(fileName, image);
            }
        }

        /// <summary>
        /// Loads all of the fonts from the content folder
        /// </summary>
        private static void LoadFontContent(ContentManager content)
        {
            fonts.Add("heading", content.Load<SpriteFont>("headingFont"));
            fonts.Add("normal", content.Load<SpriteFont>("normalFont"));
        }
    }
}
