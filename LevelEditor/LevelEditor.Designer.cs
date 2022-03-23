
namespace HW2
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
            this.groupBoxTileSelector = new System.Windows.Forms.GroupBox();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBrown = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
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
            this.groupBoxTileSelector.Controls.Add(this.buttonBlack);
            this.groupBoxTileSelector.Controls.Add(this.buttonBlue);
            this.groupBoxTileSelector.Controls.Add(this.buttonRed);
            this.groupBoxTileSelector.Controls.Add(this.buttonBrown);
            this.groupBoxTileSelector.Controls.Add(this.buttonGray);
            this.groupBoxTileSelector.Controls.Add(this.buttonGreen);
            this.groupBoxTileSelector.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTileSelector.Name = "groupBoxTileSelector";
            this.groupBoxTileSelector.Size = new System.Drawing.Size(107, 173);
            this.groupBoxTileSelector.TabIndex = 0;
            this.groupBoxTileSelector.TabStop = false;
            this.groupBoxTileSelector.Text = "Tile Selector";
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.Location = new System.Drawing.Point(57, 123);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(50, 44);
            this.buttonBlack.TabIndex = 5;
            this.buttonBlack.UseVisualStyleBackColor = false;
            this.buttonBlack.Click += new System.EventHandler(this.buttonColor_Click);
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
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonBrown
            // 
            this.buttonBrown.BackColor = System.Drawing.Color.SaddleBrown;
            this.buttonBrown.Location = new System.Drawing.Point(1, 72);
            this.buttonBrown.Name = "buttonBrown";
            this.buttonBrown.Size = new System.Drawing.Size(50, 44);
            this.buttonBrown.TabIndex = 2;
            this.buttonBrown.UseVisualStyleBackColor = false;
            this.buttonBrown.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonGray
            // 
            this.buttonGray.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonGray.Location = new System.Drawing.Point(57, 22);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(50, 44);
            this.buttonGray.TabIndex = 1;
            this.buttonGray.UseVisualStyleBackColor = false;
            this.buttonGray.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Location = new System.Drawing.Point(1, 22);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(50, 44);
            this.buttonGreen.TabIndex = 0;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // groupBoxCurrentTile
            // 
            this.groupBoxCurrentTile.Controls.Add(this.buttonCurrentTile);
            this.groupBoxCurrentTile.Location = new System.Drawing.Point(12, 191);
            this.groupBoxCurrentTile.Name = "groupBoxCurrentTile";
            this.groupBoxCurrentTile.Size = new System.Drawing.Size(107, 89);
            this.groupBoxCurrentTile.TabIndex = 1;
            this.groupBoxCurrentTile.TabStop = false;
            this.groupBoxCurrentTile.Text = "Current Tile";
            // 
            // buttonCurrentTile
            // 
            this.buttonCurrentTile.BackColor = System.Drawing.Color.Green;
            this.buttonCurrentTile.Location = new System.Drawing.Point(20, 22);
            this.buttonCurrentTile.Name = "buttonCurrentTile";
            this.buttonCurrentTile.Size = new System.Drawing.Size(66, 61);
            this.buttonCurrentTile.TabIndex = 5;
            this.buttonCurrentTile.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(23, 286);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(87, 73);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoad.Location = new System.Drawing.Point(23, 365);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(87, 73);
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
        private System.Windows.Forms.Button buttonBlack;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonBrown;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.GroupBox groupBoxCurrentTile;
        private System.Windows.Forms.Button buttonCurrentTile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxMap;
    }
}