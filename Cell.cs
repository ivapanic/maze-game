using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeForm
{
    

    class Cell
    {
        public bool _isVisited;
        public bool _isWall;
        public int _row, _column;
  
        public Cell(int row, int column)
        {
            _row = row;
            _column = column;
            _isVisited = false;
            _isWall = false;
        }

        public Cell()
        {
            _isVisited = false;
            _isWall = false;
        }

        public override string ToString()
        {
            return _isWall ? " x " : " - ";
        }
    }
}
