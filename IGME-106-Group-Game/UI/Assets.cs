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

        // - Property -
        /// <summary>
        /// A dictonary for all the game's textures
        /// </summary>
        public static Dictionary<string, Texture2D> Textures
        {
            get => textures;
        }

        // - Methods -
        /// <summary>
        /// Loads all of the assets from the uiContent folder
        /// </summary>
        public static void LoadContent(Game1 game)
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
        private void LoadLevelContent(ContentManager content)
        {
            DirectoryInfo[] uiDirectories = new DirectoryInfo(content.RootDirectory + "\\levelAssets").GetDirectories();
            foreach (DirectoryInfo uiDirectory in uiDirectories)
            {
                FileInfo[] fileInfos = uiDirectory.GetFiles("*.xnb");
                foreach (FileInfo file in fileInfos)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.Name);
                    Texture2D image = content.Load<Texture2D>("levelAssets\\" + uiDirectory.Name + "\\" + fileName);
                    textures.Add(fileName, image);
                }
            }
        }

        /// <summary>
        /// Loads all of the content from the gameObjects folder
        /// </summary>
        /// <param name="content"></param>
        private void LoadGameObjectContent(ContentManager content)
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

    }
}
