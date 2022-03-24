
namespace LevelEditor
{
    partial class LevelEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.groupBoxTileSelector = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonSouthEastWall = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonNorthWestWall = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonTopLeftWall = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonFloor = new System.Windows.Forms.Button();
            this.groupBoxCurrentTile = new System.Windows.Forms.GroupBox();
            this.buttonCurrentTile = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBoxMap = new System.Windows.Forms.GroupBox();
            this.groupBoxTileSelector.SuspendLayout();
            this.groupBoxCurrentTile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTileSelector
            // 
            this.groupBoxTileSelector.Controls.Add(this.button3);
            this.groupBoxTileSelector.Controls.Add(this.buttonSouthEastWall);
            this.groupBoxTileSelector.Controls.Add(this.button1);
            this.groupBoxTileSelector.Controls.Add(this.buttonNorthWestWall);
            this.groupBoxTileSelector.Controls.Add(this.buttonBlue);
            this.groupBoxTileSelector.Controls.Add(this.buttonRed);
            this.groupBoxTileSelector.Controls.Add(this.buttonTopLeftWall);
            this.groupBoxTileSelector.Controls.Add(this.buttonGray);
            this.groupBoxTileSelector.Controls.Add(this.buttonFloor);
            this.groupBoxTileSelector.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTileSelector.Name = "groupBoxTileSelector";
            this.groupBoxTileSelector.Size = new System.Drawing.Size(107, 279);
            this.groupBoxTileSelector.TabIndex = 0;
            this.groupBoxTileSelector.TabStop = false;
            this.groupBoxTileSelector.Text = "Tile Selector";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.Location = new System.Drawing.Point(0, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 44);
            this.button3.TabIndex = 8;
            this.button3.Tag = "BottomLeftCorner";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonSouthEastWall
            // 
            this.buttonSouthEastWall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonSouthEastWall.Image = ((System.Drawing.Image)(resources.GetObject("buttonSouthEastWall.Image")));
            this.buttonSouthEastWall.Location = new System.Drawing.Point(57, 172);
            this.buttonSouthEastWall.Name = "buttonSouthEastWall";
            this.buttonSouthEastWall.Size = new System.Drawing.Size(50, 44);
            this.buttonSouthEastWall.TabIndex = 7;
            this.buttonSouthEastWall.UseVisualStyleBackColor = false;
            this.buttonSouthEastWall.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(0, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 44);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonNorthWestWall
            // 
            this.buttonNorthWestWall.BackColor = System.Drawing.Color.Black;
            this.buttonNorthWestWall.Image = ((System.Drawing.Image)(resources.GetObject("buttonNorthWestWall.Image")));
            this.buttonNorthWestWall.Location = new System.Drawing.Point(57, 123);
            this.buttonNorthWestWall.Name = "buttonNorthWestWall";
            this.buttonNorthWestWall.Size = new System.Drawing.Size(50, 44);
            this.buttonNorthWestWall.TabIndex = 5;
            this.buttonNorthWestWall.UseVisualStyleBackColor = false;
            this.buttonNorthWestWall.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonBlue.Location = new System.Drawing.Point(0, 122);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(50, 44);
            this.buttonBlue.TabIndex = 4;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Red;
            this.buttonRed.Location = new System.Drawing.Point(57, 72);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(50, 44);
            this.buttonRed.TabIndex = 3;
            this.buttonRed.Tag = "BottomRightCorner";
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonTopLeftWall
            // 
            this.buttonTopLeftWall.BackColor = System.Drawing.Color.SaddleBrown;
            this.buttonTopLeftWall.Image = ((System.Drawing.Image)(resources.GetObject("buttonTopLeftWall.Image")));
            this.buttonTopLeftWall.Location = new System.Drawing.Point(0, 22);
            this.buttonTopLeftWall.Name = "buttonTopLeftWall";
            this.buttonTopLeftWall.Size = new System.Drawing.Size(50, 44);
            this.buttonTopLeftWall.TabIndex = 2;
            this.buttonTopLeftWall.Tag = "TopLeftCorner";
            this.buttonTopLeftWall.UseVisualStyleBackColor = false;
            this.buttonTopLeftWall.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonGray
            // 
            this.buttonGray.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonGray.Location = new System.Drawing.Point(57, 22);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(50, 44);
            this.buttonGray.TabIndex = 1;
            this.buttonGray.Tag = "TopRightCorner";
            this.buttonGray.UseVisualStyleBackColor = false;
            this.buttonGray.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonFloor
            // 
            this.buttonFloor.BackColor = System.Drawing.Color.Green;
            this.buttonFloor.Image = ((System.Drawing.Image)(resources.GetObject("buttonFloor.Image")));
            this.buttonFloor.Location = new System.Drawing.Point(1, 222);
            this.buttonFloor.Name = "buttonFloor";
            this.buttonFloor.Size = new System.Drawing.Size(50, 44);
            this.buttonFloor.TabIndex = 0;
            this.buttonFloor.Tag = "Floor";
            this.buttonFloor.UseVisualStyleBackColor = false;
            this.buttonFloor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // groupBoxCurrentTile
            // 
            this.groupBoxCurrentTile.Controls.Add(this.buttonCurrentTile);
            this.groupBoxCurrentTile.Location = new System.Drawing.Point(12, 297);
            this.groupBoxCurrentTile.Name = "groupBoxCurrentTile";
            this.groupBoxCurrentTile.Size = new System.Drawing.Size(107, 89);
            this.groupBoxCurrentTile.TabIndex = 1;
            this.groupBoxCurrentTile.TabStop = false;
            this.groupBoxCurrentTile.Text = "Current Tile";
            // 
            // buttonCurrentTile
            // 
            this.buttonCurrentTile.BackColor = System.Drawing.Color.Green;
            this.buttonCurrentTile.Image = ((System.Drawing.Image)(resources.GetObject("buttonCurrentTile.Image")));
            this.buttonCurrentTile.Location = new System.Drawing.Point(20, 22);
            this.buttonCurrentTile.Name = "buttonCurrentTile";
            this.buttonCurrentTile.Size = new System.Drawing.Size(66, 61);
            this.buttonCurrentTile.TabIndex = 5;
            this.buttonCurrentTile.Tag = "Floor";
            this.buttonCurrentTile.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(3, 392);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(59, 46);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoad.Location = new System.Drawing.Point(64, 392);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(55, 46);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load File";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBoxMap
            // 
            this.groupBoxMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMap.Location = new System.Drawing.Point(125, 12);
            this.groupBoxMap.Name = "groupBoxMap";
            this.groupBoxMap.Size = new System.Drawing.Size(471, 426);
            this.groupBoxMap.TabIndex = 4;
            this.groupBoxMap.TabStop = false;
            this.groupBoxMap.Text = "Map";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(611, 450);
            this.Controls.Add(this.groupBoxMap);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxCurrentTile);
            this.Controls.Add(this.groupBoxTileSelector);
            this.Name = "LevelEditor";
            this.Text = "Level Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckForChanges);
            this.groupBoxTileSelector.ResumeLayout(false);
            this.groupBoxCurrentTile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTileSelector;
        private System.Windows.Forms.Button buttonNorthWestWall;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonTopLeftWall;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.Button buttonFloor;
        private System.Windows.Forms.GroupBox groupBoxCurrentTile;
        private System.Windows.Forms.Button buttonCurrentTile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxMap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSouthEastWall;
        private System.Windows.Forms.Button button1;
    }
}