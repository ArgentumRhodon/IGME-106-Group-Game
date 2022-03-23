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
        private OpenFileDialog openFileDialog;
        
        // Constructor
        public Level(ContentManager content)
        {
            // Choose a level file
            //openFileDialog = new OpenFileDialog();

            //if(openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    room = new Map(content, openFileDialog.FileName);
            //}
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath += @"\Level.txt";
            room = new Map(content, _filePath);
        }
        
        // Methods
        public void Update()
        {
            //foreach(GameObject gameObject in objects)
            //{
            //    gameObject.Update();
            //}
        }

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
