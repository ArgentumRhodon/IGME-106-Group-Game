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

namespace HW2
{
    public partial class Form1 : Form
    {
        // Fields
        int width;
        int height;

        // Properties
        /// <summary>
        /// Allows the getting of the ValidWidth boolean
        /// </summary>
        public bool ValidWidth { get { return int.TryParse(textBoxWidth.Text, out width); } }

        /// <summary>
        /// Allows the getting of the ValidHeight boolean
        /// </summary>
        public bool ValidHeight { get { return int.TryParse(textBoxHeight.Text, out height); } }

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
            prompt.Filter = "Level Files|*.level";
            prompt.Title = "Open a level file.";

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
                    level = new LevelEditor(int.Parse(data[0]), int.Parse(data[1]), this);
                    data = input.ReadLine().Split(',');

                    // Converting the String[] to an int[]
                    int[] parsedData = new int[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        parsedData[i] = int.Parse(data[i]);
                    }

                    level.CreateMap(parsedData);
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
            else if (width > 30) errorMessages += "\n - Width must be 30 tiles or less";

            // Check for valid height
            if (!ValidHeight) errorMessages += "\n - Height not valid";
            else if (height < 10) errorMessages += "\n - Height must be 10 tiles or more";
            else if (height > 30) errorMessages += "\n - Height must be 30 tiles or less";

            if (errorMessages != "Errors:")
            {
                MessageBox.Show(errorMessages, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Create the new map
                LevelEditor level = new LevelEditor(width, height, this);
                level.CreateMap(Color.FromArgb(192, 192, 255));
                level.ShowDialog();
            }
        }
    }
}
