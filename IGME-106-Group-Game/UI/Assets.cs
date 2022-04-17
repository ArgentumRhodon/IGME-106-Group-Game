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
    public class Assets
    {
        // - Fields -
        private Dictionary<string, Texture2D> textures;

        // - Consturctor -
        public Assets(ContentManager content)
        {
            textures = new Dictionary<string, Texture2D>();

            try
            {
                LoadContent(content);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        // - Methods -
        /// <summary>
        /// Gets a texture based on its name
        /// </summary>
        /// <param name="key">The name of the texture</param>
        /// <returns>The texture with the given name</returns>
        public Texture2D Get(string key)
        {
            if(textures.ContainsKey(key))
            {
                return textures[key];
            }

            else
            {
                throw new KeyNotFoundException();
            }
        }

        private void LoadContent(ContentManager content)
        {
            try
            {
                LoadUIContent(content);
            }
            catch(Exception ex)
            {
                throw new Exception("UIContent loading was unsuccessful.");
            }

            try
            {
                LoadLevelContent(content);
            }
            catch (Exception ex)
            {
                throw new Exception("LevelContent loading was unsuccessful.");
            }

            try
            {
                LoadGameObjectContent(content);
            }
            catch (Exception ex)
            {
                throw new Exception("GameObjectContent loading was unsuccessful.");
            }
        }

        /// <summary>
        /// Loads all of the assets from the uiContent folder
        /// </summary>
        /// <param name="content"></param>
        private void LoadUIContent(ContentManager content)
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
