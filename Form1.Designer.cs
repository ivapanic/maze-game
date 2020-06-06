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
            this.mazePanel = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionPanel
            // 
            this.optionPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.optionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.optionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPanel.Controls.Add(this.generateButton);
            this.optionPanel.Controls.Add(this.mazePanel);
            this.optionPanel.Controls.Add(this.menuStrip1);
            this.optionPanel.Location = new System.Drawing.Point(-2, 0);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(696, 725);
            this.optionPanel.TabIndex = 0;
            // 
            // mazePanel
            // 
            this.mazePanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.mazePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mazePanel.Location = new System.Drawing.Point(28, 27);
            this.mazePanel.Name = "mazePanel";
            this.mazePanel.Size = new System.Drawing.Size(629, 624);
            this.mazePanel.TabIndex = 1;
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.generateButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(200, 643);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(261, 75);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate the maze!";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            this.generateButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.generateButton_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MazeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 718);
            this.Controls.Add(this.optionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MazeGame";
            this.Text = "Maze Game";
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel mazePanel;
        private System.Windows.Forms.Button generateButton;
    }
}

