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
        private bool _isStart;
        private bool _isEnd;
        private bool _isWall;
        private int _row, _column;
  
        public Cell(int row, int column)
        {
            setRow(row);
            setColumn(column);
        }

        public Cell()
        {
            setVisited(false);
            setWall(false);
            setStart(false);
            setEnd(false);
        }

        public void setRow(int row)
        {
            _row = row;
        }

        public void setColumn(int column)
        {
            _column = column;
        }

        public void setStart(bool val)
        {
            _isStart = val;
        }

        public bool isStart()
        {
            return _isStart;
        }

        public void setEnd(bool val)
        {
            _isEnd = val;
        }

        public bool isEnd()
        {
            return _isEnd;
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

        public override string ToString()
        {
            return _isWall ? "X" : "-";
        }
    }
}
