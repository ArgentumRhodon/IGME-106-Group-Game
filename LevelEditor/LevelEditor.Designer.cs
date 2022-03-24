
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
            this.buttonBottomLeftCorner = new System.Windows.Forms.Button();
            this.buttonEastWall = new System.Windows.Forms.Button();
            this.buttonSouthWall = new System.Windows.Forms.Button();
            this.buttonNorthWall = new System.Windows.Forms.Button();
            this.buttonWestWall = new System.Windows.Forms.Button();
            this.buttonBottomRightCorner = new System.Windows.Forms.Button();
            this.buttonTopLeftCorner = new System.Windows.Forms.Button();
            this.buttonTopRightCorner = new System.Windows.Forms.Button();
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
            this.groupBoxTileSelector.Controls.Add(this.buttonBottomLeftCorner);
            this.groupBoxTileSelector.Controls.Add(this.buttonEastWall);
            this.groupBoxTileSelector.Controls.Add(this.buttonSouthWall);
            this.groupBoxTileSelector.Controls.Add(this.buttonNorthWall);
            this.groupBoxTileSelector.Controls.Add(this.buttonWestWall);
            this.groupBoxTileSelector.Controls.Add(this.buttonBottomRightCorner);
            this.groupBoxTileSelector.Controls.Add(this.buttonTopLeftCorner);
            this.groupBoxTileSelector.Controls.Add(this.buttonTopRightCorner);
            this.groupBoxTileSelector.Controls.Add(this.buttonFloor);
            this.groupBoxTileSelector.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTileSelector.Name = "groupBoxTileSelector";
            this.groupBoxTileSelector.Size = new System.Drawing.Size(107, 279);
            this.groupBoxTileSelector.TabIndex = 0;
            this.groupBoxTileSelector.TabStop = false;
            this.groupBoxTileSelector.Text = "Tile Selector";
            // 
            // buttonBottomLeftCorner
            // 
            this.buttonBottomLeftCorner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonBottomLeftCorner.Location = new System.Drawing.Point(0, 72);
            this.buttonBottomLeftCorner.Name = "buttonBottomLeftCorner";
            this.buttonBottomLeftCorner.Size = new System.Drawing.Size(50, 44);
            this.buttonBottomLeftCorner.TabIndex = 8;
            this.buttonBottomLeftCorner.Tag = "BottomLeftCorner";
            this.buttonBottomLeftCorner.UseVisualStyleBackColor = false;
            this.buttonBottomLeftCorner.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonEastWall
            // 
            this.buttonEastWall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonEastWall.Image = ((System.Drawing.Image)(resources.GetObject("buttonEastWall.Image")));
            this.buttonEastWall.Location = new System.Drawing.Point(57, 172);
            this.buttonEastWall.Name = "buttonEastWall";
            this.buttonEastWall.Size = new System.Drawing.Size(50, 44);
            this.buttonEastWall.TabIndex = 7;
            this.buttonEastWall.Tag = "EastWall";
            this.buttonEastWall.UseVisualStyleBackColor = false;
            this.buttonEastWall.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonSouthWall
            // 
            this.buttonSouthWall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonSouthWall.Location = new System.Drawing.Point(0, 172);
            this.buttonSouthWall.Name = "buttonSouthWall";
            this.buttonSouthWall.Size = new System.Drawing.Size(50, 44);
            this.buttonSouthWall.TabIndex = 6;
            this.buttonSouthWall.Tag = "SouthWall";
            this.buttonSouthWall.UseVisualStyleBackColor = false;
            this.buttonSouthWall.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonNorthWall
            // 
            this.buttonNorthWall.BackColor = System.Drawing.Color.Black;
            this.buttonNorthWall.Image = ((System.Drawing.Image)(resources.GetObject("buttonNorthWall.Image")));
            this.buttonNorthWall.Location = new System.Drawing.Point(57, 123);
            this.buttonNorthWall.Name = "buttonNorthWall";
            this.buttonNorthWall.Size = new System.Drawing.Size(50, 44);
            this.buttonNorthWall.TabIndex = 5;
            this.buttonNorthWall.Tag = "NorthWall";
            this.buttonNorthWall.UseVisualStyleBackColor = false;
            this.buttonNorthWall.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonWestWall
            // 
            this.buttonWestWall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonWestWall.Location = new System.Drawing.Point(0, 122);
            this.buttonWestWall.Name = "buttonWestWall";
            this.buttonWestWall.Size = new System.Drawing.Size(50, 44);
            this.buttonWestWall.TabIndex = 4;
            this.buttonWestWall.Tag = "WestWall";
            this.buttonWestWall.UseVisualStyleBackColor = false;
            this.buttonWestWall.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonBottomRightCorner
            // 
            this.buttonBottomRightCorner.BackColor = System.Drawing.Color.Red;
            this.buttonBottomRightCorner.Location = new System.Drawing.Point(57, 72);
            this.buttonBottomRightCorner.Name = "buttonBottomRightCorner";
            this.buttonBottomRightCorner.Size = new System.Drawing.Size(50, 44);
            this.buttonBottomRightCorner.TabIndex = 3;
            this.buttonBottomRightCorner.Tag = "BottomRightCorner";
            this.buttonBottomRightCorner.UseVisualStyleBackColor = false;
            this.buttonBottomRightCorner.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonTopLeftCorner
            // 
            this.buttonTopLeftCorner.BackColor = System.Drawing.Color.SaddleBrown;
            this.buttonTopLeftCorner.Image = ((System.Drawing.Image)(resources.GetObject("buttonTopLeftCorner.Image")));
            this.buttonTopLeftCorner.Location = new System.Drawing.Point(0, 22);
            this.buttonTopLeftCorner.Name = "buttonTopLeftCorner";
            this.buttonTopLeftCorner.Size = new System.Drawing.Size(50, 44);
            this.buttonTopLeftCorner.TabIndex = 2;
            this.buttonTopLeftCorner.Tag = "TopLeftCorner";
            this.buttonTopLeftCorner.UseVisualStyleBackColor = false;
            this.buttonTopLeftCorner.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonTopRightCorner
            // 
            this.buttonTopRightCorner.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonTopRightCorner.Location = new System.Drawing.Point(57, 22);
            this.buttonTopRightCorner.Name = "buttonTopRightCorner";
            this.buttonTopRightCorner.Size = new System.Drawing.Size(50, 44);
            this.buttonTopRightCorner.TabIndex = 1;
            this.buttonTopRightCorner.Tag = "TopRightCorner";
            this.buttonTopRightCorner.UseVisualStyleBackColor = false;
            this.buttonTopRightCorner.Click += new System.EventHandler(this.buttonColor_Click);
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
        private System.Windows.Forms.Button buttonNorthWall;
        private System.Windows.Forms.Button buttonWestWall;
        private System.Windows.Forms.Button buttonBottomRightCorner;
        private System.Windows.Forms.Button buttonTopLeftCorner;
        private System.Windows.Forms.Button buttonTopRightCorner;
        private System.Windows.Forms.Button buttonFloor;
        private System.Windows.Forms.GroupBox groupBoxCurrentTile;
        private System.Windows.Forms.Button buttonCurrentTile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxMap;
        private System.Windows.Forms.Button buttonBottomLeftCorner;
        private System.Windows.Forms.Button buttonEastWall;
        private System.Windows.Forms.Button buttonSouthWall;
    }
}