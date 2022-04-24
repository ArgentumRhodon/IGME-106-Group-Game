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
        private int mapWidth;
        private int mapHeight;
        private int colorLevel;
        private bool changes;
        private bool inverted;
        private Form1 form;

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

        /// <summary>
        /// This property allows the getting and setting of the color level
        /// </summary>
        public int ColorLevel { get { return colorLevel; } set { colorLevel = value; } }

        // Constructors
        /// <summary>
        /// This constructor will create a new LevelEditor
        /// </summary>
        public LevelEditor(int mapWidth, int mapHeight, int colorLevel, Form1 form)
        {
            InitializeComponent();
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.colorLevel = colorLevel;
            changes = false;
            inverted = false;
            this.form = form;
            Size = new Size(tileSize * MapWidth + 175, tileSize * MapHeight + 75);
            LoadTileSprites(colorLevel);
        }

        // Methods
        /// <summary>
        /// This method will load the desired color level sprites into the buttons to use for the level
        /// </summary>
        /// <param name="color">The color level to load</param>
        public void LoadTileSprites(int color)
        {
            // Floor
            buttonFloor.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/floor/floor.png");

            // Walls
            buttonEastWall.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/wall/east.png");
            buttonNorthWall.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/wall/north.png");
            buttonSouthWall.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/wall/south.png");
            buttonWestWall.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/wall/west.png");

            // Corners
            buttonBottomLeftCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/corner/bottomLeft.png");
            buttonBottomRightCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/corner/bottomRight.png");
            buttonTopLeftCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/corner/topLeft.png");
            buttonTopRightCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{color}/corner/topRight.png");
        }

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
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/floor/floor.png");
                            pb.Tag = "Floor";
                            break;

                        case '1': // Top Left Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/topLeft.png");
                            pb.Tag = "TopLeftCorner";
                            break;

                        case '2': // Top Right Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/topRight.png");
                            pb.Tag = "TopRightCorner";
                            break;

                        case '3': // Bottom Left Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/bottomLeft.png");
                            pb.Tag = "BottomLeftCorner";
                            break;

                        case '4': // Bottom Right Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/bottomRight.png");
                            pb.Tag = "BottomRightCorner";
                            break;

                        case '5': // Inverted Top Left Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/topLeft.1.png");
                            pb.Tag = "InvertedTopLeftCorner";
                            break;

                        case '6': // Inverted Top Right Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/topRight.1.png");
                            pb.Tag = "InvertedTopRightCorner";
                            break;

                        case '7': // Inverted Bottom Left Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/bottomLeft.1.png");
                            pb.Tag = "InvertedBottomLeftCorner";
                            break;

                        case '8': // Inverted Bottom Right Corner
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/bottomRight.1.png");
                            pb.Tag = "InvertedBottomRightCorner";
                            break;

                        case 'A': // North Wall
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/wall/north.png");
                            pb.Tag = "NorthWall";
                            break;

                        case 'B': // East Wall
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/wall/east.png");
                            pb.Tag = "EastWall";
                            break;

                        case 'C': // South Wall
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/wall/south.png");
                            pb.Tag = "SouthWall";
                            break;

                        case 'D': // West Wall
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/wall/west.png");
                            pb.Tag = "WestWall";
                            break;

                        case '~': // Center Wall
                            pb.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/wall/center.png");
                            pb.Tag = "CenterWall";
                            break;

                        case '\n': // Need to ignore newline characters
                            break;

                        default: // Invalid input
                            MessageBox.Show("Invalid input detected in level file, check to make sure valid characters are used in the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                    output = new StreamWriter($"../../../../IGME-106-Group-Game/Content/Levels/{splitDirectory[splitDirectory.Length - 1]}");
                    output.WriteLine($"{mapWidth},{mapHeight},{colorLevel}");
                    for (int j = 0; j < MapHeight; j++)
                    {
                        for (int i = 0; i < MapWidth; i++)
                        {
                            output.Write($"{images[i,j]}");
                        }
                        output.Write("\n");
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
                        case "InvertedTopLeftCorner":
                            images[x, y] = '5';
                            break;
                        case "InvertedTopRightCorner":
                            images[x, y] = '6';
                            break;
                        case "InvertedBottomLeftCorner":
                            images[x, y] = '7';
                            break;
                        case "InvertedBottomRightCorner":
                            images[x, y] = '8';
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
                        case "CenterWall":
                            images[x, y] = '~';
                            break;
                    }
                }
            }

            return images;
        }

        private void buttonInvert_Click(object sender, EventArgs e)
        {
            if (inverted)
            {
                buttonBottomLeftCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/bottomLeft.png");
                buttonBottomLeftCorner.Tag = "BottomLeftCorner";
                buttonBottomRightCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/bottomRight.png");
                buttonBottomRightCorner.Tag = "BottomRightCorner";
                buttonTopLeftCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/topLeft.png");
                buttonTopLeftCorner.Tag = "TopLeftCorner";
                buttonTopRightCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/corner/topRight.png");
                buttonTopRightCorner.Tag = "TopRightCorner";
                buttonFloor.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/floor/floor.png");
                buttonFloor.Tag = "Floor";
                inverted = false;
            }
            else
            {
                buttonBottomLeftCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/bottomLeft.1.png");
                buttonBottomLeftCorner.Tag = "InvertedBottomLeftCorner";
                buttonBottomRightCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/bottomRight.1.png");
                buttonBottomRightCorner.Tag = "InvertedBottomRightCorner";
                buttonTopLeftCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/topLeft.1.png");
                buttonTopLeftCorner.Tag = "InvertedTopLeftCorner";
                buttonTopRightCorner.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/outCorner/topRight.1.png");
                buttonTopRightCorner.Tag = "InvertedTopRightCorner";
                buttonFloor.Image = Image.FromFile($"../../../../LevelEditor/Tiles/{colorLevel}/wall/center.png");
                buttonFloor.Tag = "CenterWall";
                inverted = true;
            }
        }
    }
}
