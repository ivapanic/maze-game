using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace MazeForm
{
    class Maze
    {

        int _length;
        List<Cell> _mazeCells;
        List<Cell> _mazeWalls;
        Cell _currentCell;
        Cell[,] _maze;
        Stack<Cell> _cellStack;

        private Random _rand;

        public Maze(int length)
        {
            _length = length;

            _mazeCells = new List<Cell>();
            _mazeWalls = new List<Cell>();

            for (var i = 0; i < _length; ++i)
            {
                for (var j = 0; j < _length; ++j)
                {
                    Cell cell = new Cell(i, j);
                    if (i % 2 == 0 || j % 2 == 0)
                    {
                        cell._isWall = true;
                        _mazeWalls.Add(cell);
                    }
                    else
                    {
                        _mazeCells.Add(cell);
                    }
                }
            }
            _rand = new Random();
            _cellStack = new Stack<Cell>();
            _maze = new Cell[_length, _length];
        }

        void addNeighbour(List<Cell> neighbourCells, params Cell[] cells)
        {
            foreach (Cell cell in cells)
            { if (cell != null)
                    if (cell._isVisited == false)
                        neighbourCells.Add(cell);
            }
        }
        Cell getRandomNeighbour()
        {
            List<Cell> neighbourCells = new List<Cell>();
            Cell southN, northN, eastN, westN;
            northN = _currentCell._row - 2 > 0 ? _mazeCells.Find(cell => _currentCell._row - 2 == cell._row && _currentCell._column == cell._column) : null;
            southN = _currentCell._row + 2 < _length - 1 ? _mazeCells.Find(cell => _currentCell._row + 2 == cell._row && _currentCell._column == cell._column) : null;
            eastN = _currentCell._column + 2 < _length - 1 ? _mazeCells.Find(cell => _currentCell._row == cell._row && _currentCell._column + 2 == cell._column) : null;
            westN = _currentCell._column - 2 < 0 ? _mazeCells.Find(cell => _currentCell._row == cell._row && _currentCell._column - 2 == cell._column) : null;

            addNeighbour(neighbourCells, northN, southN, eastN, westN);
            int rand_index = _rand.Next(0, neighbourCells.Count);

            return neighbourCells.Count > 0 ? neighbourCells.ElementAt(rand_index) : null;
        }

        void removeTheWall(Cell currentCell, Cell neighbourCell)
        {
            int row = currentCell._row;
            int column = _currentCell._column;

            if (row == neighbourCell._row)
            {
                column = neighbourCell._column > column ? neighbourCell._column - 1 : neighbourCell._column + 1;
            }
            else if (column == neighbourCell._column)
            {
                row = neighbourCell._row > row ? neighbourCell._row - 1 : neighbourCell._row + 1;
            }

            foreach (Cell wall in _mazeWalls)
            {
                if (wall._row == row && wall._column == column)
                {
                    wall._isWall = false;
                    wall._isVisited = true;
                    _mazeCells.Add(wall);
                   
                }
            }

            var toBeRemovedWall = _mazeWalls.Find(wall => !wall._isWall);
            _mazeWalls.Remove(toBeRemovedWall);
        }

        public void mazeGeneration()
        {
            _cellStack.Push(_mazeCells.ElementAt(0));
            _mazeCells.ElementAt(0)._isVisited = true;

            do
            {
                _currentCell = _cellStack.Pop();
                Cell neighbourCell = getRandomNeighbour();
                if (neighbourCell != null)
                {
                    removeTheWall(_currentCell, neighbourCell);
                    neighbourCell._isVisited = true;
                    _cellStack.Push(neighbourCell);
                }
            } while (_cellStack.Count > 0);
        }

        public void mazeVisualisation(Cell[,] _maze)
        {
            foreach (Cell wall in _mazeWalls)
            {
                _maze[wall._row, wall._column] = wall;
            }

            foreach (Cell cell in _mazeCells)
            {
                _maze[cell._row, cell._column] = cell;

            }
        }

        public void print()
        {
            mazeVisualisation(_maze);

            for (int i = 0; i < _length; ++i)
            {
                for (int j = 0; j < _length; ++j)
                {
                    Console.Write(_maze[i, j]);
                }
                Console.WriteLine();
            }
        }

      
    }
}
