﻿
namespace LevelEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.textBoxColorLevel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(204, 52);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Map";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.Controls.Add(this.label1);
            this.groupBoxCreate.Controls.Add(this.textBoxColorLevel);
            this.groupBoxCreate.Controls.Add(this.buttonCreate);
            this.groupBoxCreate.Controls.Add(this.textBoxHeight);
            this.groupBoxCreate.Controls.Add(this.textBoxWidth);
            this.groupBoxCreate.Controls.Add(this.labelHeight);
            this.groupBoxCreate.Controls.Add(this.labelWidth);
            this.groupBoxCreate.Location = new System.Drawing.Point(16, 70);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(200, 203);
            this.groupBoxCreate.TabIndex = 1;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "Create New Map";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(6, 114);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(187, 69);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Create Map";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(93, 43);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 23);
            this.textBoxHeight.TabIndex = 3;
            this.textBoxHeight.Text = "18";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(93, 16);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 23);
            this.textBoxWidth.TabIndex = 2;
            this.textBoxWidth.Text = "32";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(6, 46);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(88, 15);
            this.labelHeight.TabIndex = 1;
            this.labelHeight.Text = "Height (in tiles)";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(6, 19);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(84, 15);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Width (in tiles)";
            // 
            // textBoxColorLevel
            // 
            this.textBoxColorLevel.Location = new System.Drawing.Point(93, 73);
            this.textBoxColorLevel.Name = "textBoxColorLevel";
            this.textBoxColorLevel.Size = new System.Drawing.Size(100, 23);
            this.textBoxColorLevel.TabIndex = 5;
            this.textBoxColorLevel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Color Level (0-4)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 288);
            this.Controls.Add(this.groupBoxCreate);
            this.Controls.Add(this.buttonLoad);
            this.Name = "Form1";
            this.Text = "Level Editor";
            this.groupBoxCreate.ResumeLayout(false);
            this.groupBoxCreate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxColorLevel;
    }
}

