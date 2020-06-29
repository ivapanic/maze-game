namespace MazeForm
{
    partial class MazeGame
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
            this.optionPanel = new System.Windows.Forms.Panel();
            this.controlButton = new System.Windows.Forms.Button();
            this.mazePanel = new System.Windows.Forms.Panel();
            this.hardModeButton = new System.Windows.Forms.Button();
            this.intermediateModeButton = new System.Windows.Forms.Button();
            this.easyModeButton = new System.Windows.Forms.Button();
            this.modeButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.changeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comfyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardcoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionPanel.SuspendLayout();
            this.mazePanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionPanel
            // 
            this.optionPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.optionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.optionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPanel.Controls.Add(this.controlButton);
            this.optionPanel.Controls.Add(this.mazePanel);
            this.optionPanel.Controls.Add(this.menuStrip1);
            this.optionPanel.Location = new System.Drawing.Point(-2, 0);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(696, 771);
            this.optionPanel.TabIndex = 0;
            // 
            // controlButton
            // 
            this.controlButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.controlButton.Enabled = false;
            this.controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlButton.Location = new System.Drawing.Point(196, 657);
            this.controlButton.Name = "controlButton";
            this.controlButton.Size = new System.Drawing.Size(261, 107);
            this.controlButton.TabIndex = 0;
            this.controlButton.Text = "Use cursor or arrows to get to the end of the maze without touching any walls!";
            this.controlButton.UseVisualStyleBackColor = false;
            this.controlButton.Click += new System.EventHandler(this.controlButton_Click);
            this.controlButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.controlButton_KeyDown);
            // 
            // mazePanel
            // 
            this.mazePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mazePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mazePanel.Controls.Add(this.hardModeButton);
            this.mazePanel.Controls.Add(this.intermediateModeButton);
            this.mazePanel.Controls.Add(this.easyModeButton);
            this.mazePanel.Controls.Add(this.modeButton);
            this.mazePanel.Location = new System.Drawing.Point(28, 27);
            this.mazePanel.Name = "mazePanel";
            this.mazePanel.Size = new System.Drawing.Size(622, 624);
            this.mazePanel.TabIndex = 1;
            // 
            // hardModeButton
            // 
            this.hardModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hardModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hardModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hardModeButton.Location = new System.Drawing.Point(377, 287);
            this.hardModeButton.Name = "hardModeButton";
            this.hardModeButton.Size = new System.Drawing.Size(121, 44);
            this.hardModeButton.TabIndex = 3;
            this.hardModeButton.Text = "HARDCORE";
            this.hardModeButton.UseVisualStyleBackColor = false;
            this.hardModeButton.Click += new System.EventHandler(this.hardModeButton_Click);
            // 
            // intermediateModeButton
            // 
            this.intermediateModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.intermediateModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.intermediateModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intermediateModeButton.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.intermediateModeButton.Location = new System.Drawing.Point(249, 287);
            this.intermediateModeButton.Name = "intermediateModeButton";
            this.intermediateModeButton.Size = new System.Drawing.Size(111, 44);
            this.intermediateModeButton.TabIndex = 2;
            this.intermediateModeButton.Text = "NORMIE";
            this.intermediateModeButton.UseVisualStyleBackColor = false;
            this.intermediateModeButton.Click += new System.EventHandler(this.intermediateModeButton_Click);
            // 
            // easyModeButton
            // 
            this.easyModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.easyModeButton.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.easyModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.easyModeButton.Location = new System.Drawing.Point(115, 287);
            this.easyModeButton.Name = "easyModeButton";
            this.easyModeButton.Size = new System.Drawing.Size(114, 44);
            this.easyModeButton.TabIndex = 1;
            this.easyModeButton.Text = "COMFY";
            this.easyModeButton.UseVisualStyleBackColor = false;
            this.easyModeButton.Click += new System.EventHandler(this.easyModeButton_Click);
            // 
            // modeButton
            // 
            this.modeButton.BackColor = System.Drawing.Color.Black;
            this.modeButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.modeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.modeButton.Location = new System.Drawing.Point(115, 196);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(383, 61);
            this.modeButton.TabIndex = 0;
            this.modeButton.Text = "GAME MODE";
            this.modeButton.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // changeModeToolStripMenuItem
            // 
            this.changeModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comfyToolStripMenuItem,
            this.normieToolStripMenuItem,
            this.hardcoreToolStripMenuItem});
            this.changeModeToolStripMenuItem.Enabled = false;
            this.changeModeToolStripMenuItem.Name = "changeModeToolStripMenuItem";
            this.changeModeToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.changeModeToolStripMenuItem.Text = "Change mode";
            // 
            // comfyToolStripMenuItem
            // 
            this.comfyToolStripMenuItem.Name = "comfyToolStripMenuItem";
            this.comfyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.comfyToolStripMenuItem.Text = "Comfy";
            this.comfyToolStripMenuItem.Click += new System.EventHandler(this.comfyToolStripMenuItem_Click);
            // 
            // normieToolStripMenuItem
            // 
            this.normieToolStripMenuItem.Name = "normieToolStripMenuItem";
            this.normieToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.normieToolStripMenuItem.Text = "Normie";
            this.normieToolStripMenuItem.Click += new System.EventHandler(this.normieToolStripMenuItem_Click);
            // 
            // hardcoreToolStripMenuItem
            // 
            this.hardcoreToolStripMenuItem.Name = "hardcoreToolStripMenuItem";
            this.hardcoreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hardcoreToolStripMenuItem.Text = "Hardcore";
            this.hardcoreToolStripMenuItem.Click += new System.EventHandler(this.hardcoreToolStripMenuItem_Click);
            // 
            // MazeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 769);
            this.Controls.Add(this.optionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MazeGame";
            this.Text = "Maze Game";
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            this.mazePanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.Panel mazePanel;
        private System.Windows.Forms.Button controlButton;
        private System.Windows.Forms.Button modeButton;
        private System.Windows.Forms.Button hardModeButton;
        private System.Windows.Forms.Button intermediateModeButton;
        private System.Windows.Forms.Button easyModeButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comfyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardcoreToolStripMenuItem;
    }
}

