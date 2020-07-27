using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;

namespace MazeForm
{
    public partial class MazeGame : Form
    {
        public Color _startColor { get; set; }
        public Color _endColor { get; set; }
        public Color _wallColor { get; set; }
        public Color _pathColor { get; set; }
        public Color _visitedPathColor { get; set; }
        public Color _visitedWallColor { get; set; }

        const int LENGTH = 620;

        MazeButton[,] mazeButtons;
        Maze maze;
        Cell[,] mazeCells;
        MazeButton previousButton;
        Dictionary<char, int> coordinates = new Dictionary<char, int>();
        char x = 'x'; char y = 'y';
        bool endGame;
        Mode mode;
        bool firstGeneration = true;

        public class MazeButton : Button
        {
            public int X { get; set; }
            public int Y { get; set; }

        }

        public MazeGame()
        {
            InitializeComponent();
        }

        public void setMazeColorScheme(Color startColor, Color endColor, Color wallColor, Color pathColor, Color visitedPathColor, Color visitedWallColor)
        {
            _startColor = startColor;
            _endColor = endColor;
            _wallColor = wallColor;
            _pathColor = pathColor;
            _visitedPathColor = visitedPathColor;
            _visitedWallColor = visitedWallColor;
        }

        public void mazeInit(Mode mode)
        {
            maze = new Maze(mode);
            mazeCells = maze.mazeGeneration();
            mazeButtons = new MazeButton[Maze.length, Maze.length];
            coordinates[x] = 1; coordinates[y] = 0;
            previousButton = new MazeButton();
            previousButton.X = 1; previousButton.Y = 0;

            setMazeColorScheme(Color.Blue, Color.ForestGreen, Color.Black, Color.White, Color.BlueViolet, Color.Red);

            endGame = false;
            showMaze();
        }

        private void startMazeMode(Mode mode)
        {
            showModeButtons(false);
            mazeInit(mode);
            firstGeneration = false;
            controlButton.Enabled = true;
            changeModeToolStripMenuItem.Enabled = true;
            controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            controlButton.Text = "Regenerate the maze!";

        }

        private void showMaze()
        {
            for (int i = 0; i < Maze.length; ++i)
            {
                for (int j = 0; j < Maze.length; ++j)
                {
                    MazeButton button = new MazeButton();
                    button.X = i; button.Y = j;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Height = LENGTH / Maze.length; 
                    button.Width = LENGTH / Maze.length;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Location = new Point(i * button.Height, j * button.Width);
                    button.Enabled = false;
                   
                    button = mazeColoring(mazeCells, i, j, button, _startColor, _endColor, _wallColor, _pathColor);

                    mazeButtons[i, j] = button;
                    mazePanel.Controls.Add(button);
                }
            }
            foreach (Button btn in mazeButtons)
            {
                btn.MouseEnter += btn_MouseEnter;
            }
        }

        private MazeButton mazeColoring(Cell[,] mazeCells, int i, int j, MazeButton button, Color startColor, Color endColor, Color wallColor, Color pathColor)
        {
            if (mazeCells[i, j].isWall())
            {
                if (mazeCells[i, j].isStart())
                {
                    setButtonColor(button, startColor, startColor, startColor);
                    button.Enabled = true;

                }
                else if (mazeCells[i, j].isEnd())
                    setButtonColor(button, endColor, endColor, endColor);

                else
                    setButtonColor(button, wallColor, wallColor, wallColor);
            }
            else
                setButtonColor(button, pathColor, pathColor, pathColor);

            return button;
        }


        private void setButtonColor(Button button, Color foreColor, Color backColor, Color borderColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatAppearance.BorderColor = borderColor;
        }


        private void outcome(MazeButton button)
        {
            if (mazeCells[button.X, button.Y].isWall() && !mazeCells[button.X, button.Y].isStart() && !mazeCells[button.X, button.Y].isEnd())
            {
                controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                controlButton.Text = "YOU LOST\nRestart?";
                enableAllButtons(false);
                endGame = true;
            }
            else if (mazeCells[button.X, button.Y].isEnd() && button.Y == previousButton.Y + 1)
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
            var button = (MazeButton)sender;
            if (button.BackColor == _startColor)
            {
                enableAllButtons(true);
            }

            if (button.BackColor == _wallColor)
                button.BackColor =_visitedWallColor;
            else
                if (!(button.BackColor == _startColor) && !(button.BackColor == _endColor) && (Math.Abs(button.X - previousButton.X) == 1 || Math.Abs(button.Y - previousButton.Y) == 1))
                {
                    setButtonColor(button, _visitedPathColor, _visitedPathColor, _visitedPathColor);
                    previousButton = button;
                }

            outcome(button);

        }

        private void controlButton_Click(object sender, EventArgs e)
        {
            mazePanel.Controls.Clear();
            showModeButtons(true);
            
            if (!firstGeneration)
            {
                controlButton.Enabled = true;
            }

            if (controlButton.Text == "YOU LOST" || controlButton.Text == "YOU WON")
            {
                Array.Clear(mazeButtons, 0, mazeButtons.Length);
                mazePanel.Refresh();
            }

            startMazeMode(mode);

            controlButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            controlButton.Text = "Regenerate the maze!";
        }

        private void controlButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controlButton.PerformClick();
            }
        }

        private void walkThroughMazeButtonsKeyboard(MazeButton button, Keys keyData)
        {
            if (maze.getMaze()[button.X, button.Y].isStart() && keyData == Keys.Up)
                return;
            else
            {
                switch (keyData)
                {
                    case (Keys.Up):
                        button.Y -= 1;
                        break;
                    case (Keys.Down):
                        button.Y += 1;
                        break;
                    case (Keys.Left):
                        button.X -= 1;
                        break;
                    case (Keys.Right):
                        button.X += 1;
                        break;
                }

                if (!maze.getMaze()[button.X, button.Y].isEnd() && !maze.getMaze()[button.X, button.Y].isStart())
                {
                    if (maze.getMaze()[button.X, button.Y].isWall())
                    {
                        setButtonColor(mazeButtons[button.X, button.Y], _visitedWallColor, _visitedWallColor, _visitedWallColor);
                    }
                    else
                    {
                        setButtonColor(mazeButtons[button.X, button.Y], _visitedPathColor, _visitedPathColor, _visitedPathColor);
                    }
                }

                outcome(mazeButtons[button.X, button.Y]);
                previousButton = mazeButtons[button.X, button.Y];
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (endGame) { return false; }
            else if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                try
                {
                    walkThroughMazeButtonsKeyboard(mazeButtons[1, 0], keyData);
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    return false;
                };
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

     
        private void showModeButtons(bool visible)
        {
            modeButton.Visible = visible;
            easyModeButton.Visible = visible;
            intermediateModeButton.Visible = visible;
            hardModeButton.Visible = visible;

        }

        private void easyModeButton_Click(object sender, EventArgs e)
        {
            mode = Mode.EASY;
            startMazeMode(mode);
        }

        private void intermediateModeButton_Click(object sender, EventArgs e)
        {
            mode = Mode.INTERMEDIATE;
            startMazeMode(mode);
        }

        private void hardModeButton_Click(object sender, EventArgs e)
        {
            mode = Mode.HARD;
            startMazeMode(mode);
        }

        private void comfyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mazePanel.Controls.Clear();
            mode = Mode.EASY;
            startMazeMode(mode);
        }

        private void normieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mazePanel.Controls.Clear();
            mode = Mode.INTERMEDIATE;
            startMazeMode(mode);
        }

        private void hardcoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mazePanel.Controls.Clear();
            mode = Mode.HARD;
            startMazeMode(mode);
        }
    }
}

