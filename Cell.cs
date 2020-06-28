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
        private bool _isVisited;
        private bool _isWall;
        private int _row, _column;
  
        public Cell(int row, int column)
        {
            _row = row;
            _column = column;
            _isVisited = false;
            setWall(false);
        }

        public void setWall(bool val)
        {
            _isWall = val;
        }

        public void setVisited(bool val)
        {
            _isVisited = val;
        }

        public bool isVisited()
        {
            return _isVisited;
        }

        public bool isWall()
        {
            return _isWall;
        }

        public int getRow()
        {
            return _row;
        }

        public int getColumn()
        {
            return _column;
        }

        public Cell()
        {
            _isVisited = false;
            _isWall = false;
        }

        public override string ToString()
        {
            return _isWall ? "X" : "-";
        }
    }
}
