using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        // Fields
        private int width;
        private int height;
        private int color;

        // Properties
        /// <summary>
        /// Allows the getting of the ValidWidth boolean
        /// </summary>
        public bool ValidWidth { get { return int.TryParse(textBoxWidth.Text, out width); } }

        /// <summary>
        /// Allows the getting of the ValidHeight boolean
        /// </summary>
        public bool ValidHeight { get { return int.TryParse(textBoxHeight.Text, out height); } }

        /// <summary>
        /// Allows the getting of the ValidColorLevel boolean
        /// </summary>
        public bool ValidColorLevel { get { return int.TryParse(textBoxColorLevel.Text, out color); } }

        // Constructors
        public Form1()
        {
            InitializeComponent();
        }

        // Methods
        /// <summary>
        /// This method will prompt the user to load a selected file
        /// </summary>
        public void LoadFile()
        {
            // Prompt user for file choice
            OpenFileDialog prompt = new OpenFileDialog();
            prompt.Filter = "Text Files|*.txt"; // SUBJECT TO CHANGE
            prompt.Title = "Open a level file.";

            // If user inputs a file
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                // Load the file
                StreamReader input = null;
                String[] data;
                LevelEditor level = null;
                try
                {
                    input = new StreamReader(prompt.FileName);

                    // Get the width and height and instantiate the LevelEditor with the correct dimensions before reading in tiles
                    data = input.ReadLine().Split(',');
                    level = new LevelEditor(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]), this);
                    char[,] tileArray = new char[int.Parse(data[0]), int.Parse(data[1])];
                    // Swap the line below with the two above when level size is ready to implement
                    //level = new LevelEditor(32, 18, this);
                    for (int j = 0; j < tileArray.GetLength(1); j++) // height
                    {
                        for (int i = 0; i < tileArray.GetLength(0); i++) // width
                        {
                            tileArray[i, j] = (char)input.Read();
                            if (tileArray[i,j] == '\n') tileArray[i, j] = (char)input.Read();
                        }
                        input.Read();
                    }

                    level.CreateMap(tileArray);
                    String[] splitDirectory = prompt.FileName.Split('\\');
                    level.Text = $"Level Editor - {splitDirectory[splitDirectory.Length - 1]}";
                    MessageBox.Show("Load successful.", "File Load Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    level.ShowDialog();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (level != null) level.Close();
                    if (input != null) input.Close();
                }
            }
        }
        /// <summary>
        /// This method will call LoadFile upon button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// This method will create a new map with the designated constraints
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            String errorMessages = "Errors:";

            // Check for valid width
            if (!ValidWidth) errorMessages += "\n - Width not valid";
            else if (width < 10) errorMessages += "\n - Width must be 10 tiles or more";
            else if (width > 50) errorMessages += "\n - Width must be 50 tiles or less";

            // Check for valid height
            if (!ValidHeight) errorMessages += "\n - Height not valid";
            else if (height < 10) errorMessages += "\n - Height must be 10 tiles or more";
            else if (height > 50) errorMessages += "\n - Height must be 50 tiles or less";

            // Check for valid colorLevel
            if (!ValidColorLevel) errorMessages += "\n - Color Level not valid";
            else if (color < 0) errorMessages += "\n - Color Level must be 0 or more";
            else if (color > 4) errorMessages += "\n - Color Level must be 4 or less";

            if (errorMessages != "Errors:")
            {
                MessageBox.Show(errorMessages, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Create the new map
                LevelEditor level = new LevelEditor(width, height, color, this);
                level.CreateMap();
                level.ShowDialog();
            }
        }
    }
}
