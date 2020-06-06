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


        public MazeGame()
        {
            InitializeComponent();
        }

        public void mazeInit()
        {
            Maze maze = new Maze();
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

            btn.BackColor = btn.BackColor == Color.Black ? Color.Red : Color.BlueViolet;


            if (btn.BackColor == Color.Red)
            {
                generateButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                setButtonColor(generateButton, generateButton.ForeColor, Color.MediumVioletRed, generateButton.FlatAppearance.BorderColor);
                generateButton.Text = "YOU LOST";
                enableAllButtons(false);
            }

            if (btn.ForeColor == Color.ForestGreen)
            {
                generateButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                setButtonColor(generateButton, generateButton.ForeColor, Color.LightGreen, generateButton.FlatAppearance.BorderColor);
                generateButton.Text = "YOU WON";
                enableAllButtons(false);


            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.BackColor != Color.Red)
            {
                btn.BackColor = btn.FlatAppearance.BorderColor;
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
                btn.MouseLeave += btn_MouseLeave;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            mazeInit();
            showMaze();

            generateButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            generateButton.Text = "Try to get to the end of the maze using you cursor without touching any walls!";

            if(generateButton.Text == "YOU LOST") //to do - restart option
            {
              /* Array.Clear(mazeButtons, 0, mazeButtons.Length);
               mazeInit();
               showMaze();
               mazePanel.Refresh();*/
            }

       }

        private void generateButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generateButton.PerformClick();
            }
        }
     
    }
}

