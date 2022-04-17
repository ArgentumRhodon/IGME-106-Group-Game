using IGME106GroupGame.UI;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IGME106GroupGame.Levels
{
    class Level
    {
        // Fields
        // private List<GameObject> objects;
        private Map room;

        // Select test level file
        //private OpenFileDialog openFileDialog;
        
        // Constructor
        /// <summary>
        /// This constructor will instantiate a new level
        /// </summary>
        /// <param name="content">The Content Manager</param>
        public Level(Assets assets)
        {
            // Choose a level file
            //openFileDialog = new OpenFileDialog();

            //if(openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    room = new Map(content, openFileDialog.FileName);
            //}
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath += @"\Level.txt";
            room = new Map(assets, _filePath);
        }
        
        // Methods
        /// <summary>
        /// This method will update the level (currently disabled)
        /// </summary>
        public void Update()
        {
            //foreach(GameObject gameObject in objects)
            //{
            //    gameObject.Update();
            //}
        }

        /// <summary>
        /// This method will draw the level to the screen
        /// </summary>
        /// <param name="_spriteBatch"></param>
        public void Draw(SpriteBatch _spriteBatch)
        {
            room.Draw(_spriteBatch);
            //foreach(GameObject gameObject in objects)
            //{
            //    gameObject.Draw(_spriteBatch);
            //}
        }
    }
}
