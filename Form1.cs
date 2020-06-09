using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeForm
{
    public partial class MazeGame : Form
    {
        public String[] text;
        Button[,] mazeButtons = new Button[Maze._length, Maze._length];
        Maze maze;


        public MazeGame()
        {
            InitializeComponent();
        }

        public void mazeInit()
        {
            maze = new Maze();
            maze.mazeGeneration();
            string filename = @".\output.txt";
            maze.print(filename);
            text = File.ReadAllLines(filename);
        }

        private void setButtonColor(Button button, Color foreColor, Color backColor, Color borderColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatAppearance.BorderColor = borderColor;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.BackColor == Color.Blue)
            {
                enableAllButtons(true);
            }

            if (btn.BackColor == Color.Black)
                btn.BackColor = Color.Red;
            else
                if (!(btn.BackColor == Color.ForestGreen))
                    setButtonColor(btn, Color.BlueViolet, Color.BlueViolet, Color.BlueViolet);
           


            if (btn.BackColor == Color.Red)
            {
                controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               // setButtonColor(controlButton, controlButton.ForeColor, Color.MediumVioletRed, controlButton.FlatAppearance.BorderColor);
                controlButton.Text = "YOU LOST\nRestart?";
                enableAllButtons(false);
            }

            else if (btn.BackColor == Color.ForestGreen)
            {
                controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
              //  setButtonColor(controlButton, controlButton.ForeColor, Color.LightGreen, controlButton.FlatAppearance.BorderColor);
                controlButton.Text = "YOU WON\nRestart?";
                enableAllButtons(false);
            }
        }

        private void enableAllButtons(bool enable)
        {
 
            foreach (Button button in mazeButtons)
            {
                if (enable)
                    button.Enabled = true;
                else
                    button.Enabled = false;
            }
        
        }


        private void showMaze()
        {
            for (int i = 0; i < Maze._length; ++i)
            {
                for (int j = 0; j < Maze._length; ++j)
                {
                    Button button = new Button();
                    button.FlatStyle = FlatStyle.Flat;
                    button.Height = 20; button.Width = 20;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Location = new Point(i * 20, j * 20);
                    button.Enabled = false;

                    if (text[i][j] == 'X')
                    {
                        if (i == 1 && j == 0)
                        {
                            setButtonColor(button, Color.Blue, Color.Blue, Color.Blue);
                            button.Enabled = true;

                        }
                        else if (i == Maze._length - 2 && j == Maze._length - 1)
                        {
                            setButtonColor(button, Color.ForestGreen, Color.ForestGreen, Color.ForestGreen);
                        }
                        else
                        {
                            setButtonColor(button, Color.Black, Color.Black, Color.Black);
                        }
                    }
                    else
                    {
                        setButtonColor(button, Color.White, Color.White, Color.White);
                    }
                    mazeButtons[i, j] = button;
                    mazePanel.Controls.Add(button);
                }
            }
            foreach (Button btn in mazeButtons)
            {
                btn.MouseEnter += btn_MouseEnter;
            }
        }

        private void controlButton_Click(object sender, EventArgs e)
        {
            mazePanel.Controls.Clear();

            if (controlButton.Text == "YOU LOST" || controlButton.Text == "YOU WON")
            {
               Array.Clear(mazeButtons, 0, mazeButtons.Length);
               mazePanel.Refresh();
            }

            mazeInit();
            showMaze();
            controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            controlButton.Text = "Try to get to the end of the maze using you cursor without touching any walls!";
        }

        private void controlButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controlButton.PerformClick();
            }
        }

        private void MazeGame_Load(object sender, EventArgs e)
        {

        }

        private void mazePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

