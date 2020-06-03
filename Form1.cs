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
        public MazeGame()
        {
            InitializeComponent();
            Maze maze = new Maze();
            maze.mazeGeneration();
            //maze.printConsole();
            maze.printFile();
            text = File.ReadAllLines(@".\output.txt");
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (text[e.Column][e.Row] == 'X')
            {
                if (e.Column == 1 && e.Row == 0)
                    e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
                else if (e.Column == Maze._length - 2 && e.Row == Maze._length - 1)
                    e.Graphics.FillRectangle(Brushes.Blue, e.CellBounds);
                else
                    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            }
        }

        private void MazeGame_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void optionPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

