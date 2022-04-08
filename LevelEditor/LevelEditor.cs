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
 * True tile size in the game is 60px by 60px, here it is lowered to 30px by 30px to fit the editor on the screen
 * 
 */

namespace LevelEditor
{
    public partial class LevelEditor : Form
    {
        // Fields
        int mapWidth;
        int mapHeight;
        bool changes;
        Form1 form;

        // Ease of use variables
        private int tileSize = 30; // For easy manipulation of tile size

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
            Size = new Size(tileSize * MapWidth + 175, tileSize * MapHeight + 75);
        }

        // Methods
        /// <summary>
        /// This method will set the colors of each tile to the corresponding color in the array
        /// </summary>
        /// <param name="colors">An array of argb ints</param>
        public void CreateMap(char[,] tiles)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    // Creating the PictureBox
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(tileSize, tileSize);

                    // Set the image to the corresponding image in the array
                    switch (tiles[x,y])
                    {
                        case '-': // Floor
                            pb.Image = buttonFloor.Image;
                            pb.Tag = buttonFloor.Tag;
                            break;

                        case '2': // Top Right Corner
                            pb.Image = buttonTopRightCorner.Image;
                            pb.Tag = buttonTopRightCorner.Tag;
                            break;

                        case '1': // Top Left Corner
                            pb.Image = buttonTopLeftCorner.Image;
                            pb.Tag = buttonTopLeftCorner.Tag;
                            break;

                        case '4': // Bottom Right Corner
                            pb.Image = buttonBottomRightCorner.Image;
                            pb.Tag = buttonBottomRightCorner.Tag;
                            break;

                        case '3': // Bottom Left Corner
                            pb.Image = buttonBottomLeftCorner.Image;
                            pb.Tag = buttonBottomLeftCorner.Tag;
                            break;

                        case 'A': // North Wall
                            pb.Image = buttonNorthWall.Image;
                            pb.Tag = buttonNorthWall.Tag;
                            break;

                        case 'B': // East Wall
                            pb.Image = buttonEastWall.Image;
                            pb.Tag = buttonEastWall.Tag;
                            break;

                        case 'C': // South Wall
                            pb.Image = buttonSouthWall.Image;
                            pb.Tag = buttonSouthWall.Tag;
                            break;

                        case 'D': // West Wall
                            pb.Image = buttonWestWall.Image;
                            pb.Tag = buttonWestWall.Tag;
                            break;
                        default: // Show error to user
                            break;
                    }

                    // Changing the location of each PictureBox to where it should be on the window
                    Point loc = pb.Location;
                    loc.X = x * (pb.Width);
                    loc.Y = y * (pb.Height);
                    pb.Location = loc;

                    // Letting the Window know the PictureBox exists, and uncapture the mouse cursor
                    groupBoxMap.Controls.Add(pb);

                    // Hooking up the PictureBox's MouseEnter and MouseDown event to pictureBoxImageAssign 
                    pb.MouseEnter += pictureBoxImageAssign_MouseEnter;
                    pb.MouseEnter += DetectChanges;
                    pb.MouseDown += pictureBoxImageAssign_Click;
                    pb.MouseDown += DetectChanges;

                    // Uncapturing the mouse upon MouseDown
                    pb.MouseDown += pictureBoxUncapture;
                }
            }
        }

        /// <summary>
        /// This overload of CreateMap will fill the map with a default tile for every square
        /// </summary>
        /// <param name="color"></param>
        public void CreateMap()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    // Creating the PictureBox
                    PictureBox pb = new PictureBox();
                    //pb.Size = new Size(groupBoxMap.Size.Width / mapWidth, groupBoxMap.Size.Height / mapHeight);
                    pb.Size = new Size(tileSize, tileSize);

                    // Set the image to the corresponding tile
                    pb.Image = buttonFloor.Image;
                    pb.Tag = "Floor";

                    // Changing the location of each PictureBox to where it should be on the window
                    Point loc = pb.Location;
                    loc.X = x * (pb.Width);
                    loc.Y = y * (pb.Height);
                    pb.Location = loc;

                    // Letting the Window know the PictureBox exists
                    groupBoxMap.Controls.Add(pb);

                    // Hooking up the PictureBox's MouseEnter and MouseDown event to pictureBoxImageAssign 
                    pb.MouseEnter += pictureBoxImageAssign_MouseEnter;
                    pb.MouseEnter += DetectChanges;
                    pb.MouseDown += pictureBoxImageAssign_Click;
                    pb.MouseDown += DetectChanges;

                    // Uncapturing the mouse upon MouseDown
                    pb.MouseDown += pictureBoxUncapture;
                }
            }
        }

        /// <summary>
        /// This method will make the selected image the image that was clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonColor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonCurrentTile.Image = button.Image;
            buttonCurrentTile.Tag = button.Tag;
        }

        /// <summary>
        /// This method will change the pictureBox moused over on to the selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxImageAssign_MouseEnter(object sender, EventArgs e)
        {
            if (!(MouseButtons == MouseButtons.Left)) return;
            PictureBox pb = (PictureBox)sender;
            pb.Image = buttonCurrentTile.Image;
            pb.Tag = buttonCurrentTile.Tag; // We use tags for file IO
        }

        /// <summary>
        /// This method will change the pictureBox clicked on to the selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxImageAssign_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Image = buttonCurrentTile.Image;
            pb.Tag = buttonCurrentTile.Tag; // We use tags for file IO
        }

        /// <summary>
        /// This method will uncapture the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxUncapture(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Capture = false;
        }

        /// <summary>
        /// This method will update the title bar with an * if changes are made
        /// </summary>
        private void DetectChanges(object sender, EventArgs e)
        {
            if (!changes)
            {
                Text += "*";
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
        private void buttonLoad_Click(object sender, EventArgs e) // check for unsaved changes, then load file, close previous file window
        {
            if (changes)
            {
                DialogResult = MessageBox.Show("There are unsaved changes. Are you sure you want to load another file?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes) form.LoadFile();
            }
            else form.LoadFile();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            char[,] images = new char[mapWidth, mapHeight];
            // Get all the PictureBox char values from images
            images = GetTiles();

            // Prompt user for file location choice ** Commented code is for if choice of directory is desired **
            SaveFileDialog prompt = new SaveFileDialog();
            prompt.Filter = "Text Files|*.txt"; // SUBJECT TO CHANGE
            prompt.Title = "Choose a name of the file to save to the Content Folder";
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                // Save the File
                StreamWriter output = null;
                try
                {
                    //output = new StreamWriter(prompt.FileName); ** For choice of directory
                    String[] splitDirectory = prompt.FileName.Split('\\');
                    output = new StreamWriter($"../../../../IGME-106-Group-Game/bin/Debug/net5.0-windows/Content/{splitDirectory[splitDirectory.Length - 1]}");
                    output.WriteLine($"{mapWidth},{mapHeight}");
                    for (int j = 0; j < MapHeight; j++)
                    {
                        for (int i = 0; i < MapWidth; i++)
                        {
                            if (j != MapWidth) output.Write($"{images[i,j]}");
                            else output.Write($"{images[i,j]}\n");
                        }
                    }
                    MessageBox.Show("Save successful.", "File Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// This method will return a 2D array of chars that represent the images on the map
        /// </summary>
        /// <returns></returns>
        private char[,] GetTiles()
        {
            char[,] images = new char[mapWidth, mapHeight];
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    PictureBox pb = (PictureBox)groupBoxMap.GetChildAtPoint(new Point(x * tileSize, y * tileSize));

                    // Convert images of tiles to characters
                    switch (pb.Tag)
                    {
                        case "Floor":
                            images[x, y] = '-';
                            break;
                        case "TopLeftCorner":
                            images[x, y] = '1';
                            break;
                        case "TopRightCorner":
                            images[x, y] = '2';
                            break;
                        case "BottomLeftCorner":
                            images[x, y] = '3';
                            break;
                        case "BottomRightCorner":
                            images[x, y] = '4';
                            break;
                        case "NorthWall":
                            images[x, y] = 'A';
                            break;
                        case "EastWall":
                            images[x, y] = 'B';
                            break;
                        case "SouthWall":
                            images[x, y] = 'C';
                            break;
                        case "WestWall":
                            images[x, y] = 'D';
                            break;
                        default:
                            return null; // Error occurred
                    }
                }
            }

            return images;
        }
    }
}
