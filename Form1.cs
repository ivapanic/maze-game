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
        bool gameStarted = false;
        Button[,] mazeButtons = new Button[Maze.length, Maze.length];
        Maze maze;
        Dictionary<char, int> coordinates = new Dictionary<char, int>();
        char x = 'x'; char y = 'y';
        bool endGame;

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
            coordinates[x] = 1; coordinates[y] = 0;
            endGame = false;
        }

        private void showMaze()
        {
            for (int i = 0; i < Maze.length; ++i)
            {
                for (int j = 0; j < Maze.length; ++j)
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
                        else if (i == Maze.length - 2 && j == Maze.length - 1)
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

        private void setButtonColor(Button button, Color foreColor, Color backColor, Color borderColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatAppearance.BorderColor = borderColor;
        }


        void outcome(Color buttonColor)
        {
            if (buttonColor == Color.Red)
            {
                controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                controlButton.Text = "YOU LOST\nRestart?";
                enableAllButtons(false);
                endGame = true;
            }
            else if (buttonColor == Color.ForestGreen)
            {
                controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                controlButton.Text = "YOU WON\nRestart?";
                enableAllButtons(false);
                endGame = true;
            }

        }

        private void enableAllButtons(bool enable)
        {
            foreach (Button button in mazeButtons)
            {
                if (enable)
                {
                    button.Enabled = true;
                }
                else
                {
                    button.Enabled = false;
                }
            }
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
                if (!(btn.BackColor == Color.ForestGreen) && !(btn.BackColor == Color.Blue))
                setButtonColor(btn, Color.BlueViolet, Color.BlueViolet, Color.BlueViolet);

            outcome(btn.BackColor);
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
            controlButton.Text = "Use cursor or arrows to get to the end of the maze without touching any walls!";
        }

        private void controlButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controlButton.PerformClick();
            }
        }

        void walkThroughMazeButtons(Button button, Dictionary<char, int> coordinates, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    coordinates[y] -= 1;
                    break;
                case (Keys.Down):
                    coordinates[y] += 1;
                    break;
                case (Keys.Left):
                    coordinates[x] -= 1;
                    break;
                case (Keys.Right):
                    coordinates[x] += 1;
                    break;
            }

            if (maze.getMaze()[coordinates[x], coordinates[y]].isWall() && coordinates[x] != Maze.length - 2 && coordinates[y] != Maze.length - 1)
            {
                mazeButtons[coordinates[x], coordinates[y]].BackColor = Color.Red;
                outcome(Color.Red);
            }
            else
            {
                if (!(mazeButtons[coordinates[x], coordinates[y]].BackColor == Color.ForestGreen))
                    setButtonColor(mazeButtons[coordinates[x], coordinates[y]], Color.BlueViolet, Color.BlueViolet, Color.BlueViolet);
            }

            if (coordinates[x] == Maze.length - 2 && coordinates[y] == Maze.length - 1)
            {
                outcome(Color.ForestGreen);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (endGame) { return false; }
            else if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                try
                {
                    walkThroughMazeButtons(mazeButtons[coordinates[x], coordinates[y]], coordinates, keyData);
                }
                catch (IndexOutOfRangeException) 
                {
                    coordinates[x] = 1; coordinates[y] = 0;
                    
                };
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

