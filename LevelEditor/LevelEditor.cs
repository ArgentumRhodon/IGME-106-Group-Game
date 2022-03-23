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

/*-----Notes-----
 * True tile size in the game is 60px by 60px, here it is lowered to 30px by 30x to fit the editor on the screen
 * 
 */

namespace HW2
{
    public partial class LevelEditor : Form
    {
        // Fields
        int mapWidth;
        int mapHeight;
        bool changes;
        Form1 form;

        // Properties
        /// <summary>
        /// This property allows the getting of the width of the map
        /// </summary>
        public int MapWidth { get { return mapWidth; } }

        /// <summary>
        /// This property allows the getting of the height of the map
        /// </summary>
        public int MapHeight { get { return mapHeight; } }

        // Constructors
        /// <summary>
        /// This constructor will create a new LevelEditor
        /// </summary>
        public LevelEditor(int mapWidth, int mapHeight, Form1 form)
        {
            InitializeComponent();
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            changes = false;
            this.form = form;
            Size = new Size(30 * MapWidth + 175, 30 * MapHeight + 75); // temp
            //Size = new Size(((mapWidth / mapHeight)) * 300 + 327, 489);
        }

        // Methods
        /// <summary>
        /// This method will set the colors of each tile to the corresponding color in the array
        /// </summary>
        /// <param name="colors">An array of argb ints</param>
        public void CreateMap(int[] colors)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    // Creating the PictureBox
                    PictureBox pb = new PictureBox();
                    //pb.Size = new Size(groupBoxMap.Size.Width / mapWidth, groupBoxMap.Size.Height / mapHeight);
                    pb.Size = new Size(30, 30);

                    // Set the color to the corresponding color in the array
                    pb.BackColor = Color.FromArgb(colors[(y * mapWidth) + x]);
                    
                    // Changing the location of each PictureBox to where it should be on the window
                    Point loc = pb.Location;
                    loc.X = x * (pb.Width);
                    loc.Y = y * (pb.Height);
                    pb.Location = loc;

                    // Letting the Window know the PictureBox exists
                    this.groupBoxMap.Controls.Add(pb);

                    // Hooking up the PictureBox's Click event to pictureBoxColorAssign and DetectChanges
                    pb.Click += pictureBoxImageAssign;
                    pb.Click += DetectChanges;
                }
            }
        }

        /// <summary>
        /// This overload of CreateMap will fill the map with a default tile for every square
        /// </summary>
        /// <param name="color"></param>
        public void CreateMap(Color color) // todo: set every tile to default floor tile
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    // Creating the PictureBox
                    PictureBox pb = new PictureBox();
                    //pb.Size = new Size(groupBoxMap.Size.Width / mapWidth, groupBoxMap.Size.Height / mapHeight);
                    pb.Size = new Size(30, 30);

                    // Set the color to the corresponding color in the 
                    pb.BackColor = color;

                    // Changing the location of each PictureBox to where it should be on the window
                    Point loc = pb.Location;
                    loc.X = x * (pb.Width);
                    loc.Y = y * (pb.Height);
                    pb.Location = loc;

                    // Letting the Window know the PictureBox exists
                    this.groupBoxMap.Controls.Add(pb);

                    // Hooking up the PictureBox's Click event to pictureBoxColorAssign 
                    pb.Click += pictureBoxImageAssign;
                    pb.Click += DetectChanges;
                }
            }
        }

        /// <summary>
        /// This method will make the selected color the color that was clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonColor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonCurrentTile.BackColor = button.BackColor;
        }

        /// <summary>
        /// This method will change the pictureBox clicked on to the selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxImageAssign(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Image = buttonCurrentTile.Image;
        }

        /// <summary>
        /// This method will update the title bar with an * if changes are made
        /// </summary>
        private void DetectChanges(object sender, EventArgs e)
        {
            if (!changes)
            {
                this.Text += "*";
                changes = true;
            }
        }

        /// <summary>
        /// This method will check if changes are not saved, and prompt the user to not quit if they want to keep their changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForChanges(object sender, FormClosingEventArgs e)
        {
            if (changes)
            {
                DialogResult = MessageBox.Show("There are unsaved changes. Are you sure you want to quit?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// This method will call LoadFile from Form1 upon click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            form.LoadFile();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Get all the PictureBox color values
            int[] colors = new int[mapWidth * mapHeight];
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    PictureBox pb = (PictureBox)groupBoxMap.GetChildAtPoint(new Point(x * groupBoxMap.Size.Width / mapWidth, y * groupBoxMap.Size.Height / mapHeight));
                    colors[(y * mapWidth) + x] = pb.BackColor.ToArgb();
                }
            }
            // Prompt user for file location choice
            SaveFileDialog prompt = new SaveFileDialog();
            prompt.Filter = "Level Files|*.level";
            prompt.Title = "Choose a place to save the file";
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                // Save the File
                StreamWriter output = null;
                try
                {
                    output = new StreamWriter(prompt.FileName);

                    output.WriteLine($"{mapWidth},{mapHeight}");
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (colors.Length - 1 == i) output.Write($"{colors[i]}");
                        else output.Write($"{colors[i]},");
                    }
                    MessageBox.Show("Save successful.", "File Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    String[] splitDirectory = prompt.FileName.Split('\\');
                    Text = $"Level Editor - {splitDirectory[splitDirectory.Length - 1]}";
                    changes = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (output != null) output.Close();
                }
            }
        }  
    }
}
