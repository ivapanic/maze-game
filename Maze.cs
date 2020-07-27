using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace MazeForm
{

    public enum Mode
    {
        EASY = 21,
        INTERMEDIATE = 31,
        HARD = 41,
    }
    class Maze
    {

        public static int length;
        private Cell[,] _maze;
        List<Cell> _mazeWalls;
        List<Cell> _mazePaths;
        Cell _currentCell;
        Stack<Cell> _cellStack;

        private Random _rand;
        
        public Cell[,] getMaze()
        {
            return _maze;
        }

        public Maze(Mode mode)
        {
            switch (mode)
            {
                case (Mode.INTERMEDIATE):
                    length = (int)Mode.INTERMEDIATE;
                    break;
                case (Mode.HARD):
                    length = (int)Mode.HARD;
                    break;
                default:
                    length = (int)Mode.EASY;
                    break;
            }

            _mazePaths = new List<Cell>();
            _mazeWalls = new List<Cell>();

            for (var i = 0; i < length; ++i)
            {
                for (var j = 0; j < length; ++j)
                {
                    Cell cell = new Cell(i, j);
                    if (i % 2 == 0 || j % 2 == 0)
                    {
                        if (i == 1 && j == 0)
                            cell.setStart(true);
                        else if (i == Maze.length - 2 && j == Maze.length - 1)
                            cell.setEnd(true);

                        cell.setWall(true);
                        _mazeWalls.Add(cell);
                    }
                    else
                    {
                        _mazePaths.Add(cell);
                    }
                }
            }
            _rand = new Random();
            _cellStack = new Stack<Cell>();
            _maze = new Cell[length, length];
        }


        void addNeighbour(List<Cell> neighbourCells, params Cell[] cells)
        {
            foreach (Cell cell in cells)
            {
                if (cell != null)
                    if (cell.isVisited() == false)
                        neighbourCells.Add(cell);
            }
        }
        Cell getRandomNeighbour()
        {
            List<Cell> neighbourCells = new List<Cell>();
            Cell southN, northN, eastN, westN;
            northN = _currentCell.getRow() - 2 > 0 ? _mazePaths.Find(cell => _currentCell.getRow() - 2 == cell.getRow() && _currentCell.getColumn() == cell.getColumn()) : null;
            southN = _currentCell.getRow() + 2 < length - 1 ? _mazePaths.Find(cell => _currentCell.getRow() + 2 == cell.getRow() && _currentCell.getColumn() == cell.getColumn()) : null;
            eastN = _currentCell.getColumn() + 2 < length - 1 ? _mazePaths.Find(cell => _currentCell.getRow() == cell.getRow() && _currentCell.getColumn() + 2 == cell.getColumn()) : null;
            westN = _currentCell.getColumn() - 2 > 0 ? _mazePaths.Find(cell => _currentCell.getRow() == cell.getRow() && _currentCell.getColumn() - 2 == cell.getColumn()) : null;

            addNeighbour(neighbourCells, northN, southN, eastN, westN);
            int rand_index = _rand.Next(0, neighbourCells.Count);

            return neighbourCells.Count > 0 ? neighbourCells.ElementAt(rand_index) : null;
        }

        void removeTheWall(Cell currentCell, Cell neighbourCell)
        {
            int row = currentCell.getRow();
            int column = _currentCell.getColumn();

            if (row == neighbourCell.getRow())
            {
                column = neighbourCell.getColumn() > column ? neighbourCell.getColumn() - 1 : neighbourCell.getColumn() + 1;
            }
            else if (column == neighbourCell.getColumn())
            {
                row = neighbourCell.getRow() > row ? neighbourCell.getRow() - 1 : neighbourCell.getRow() + 1;
            }

            foreach (Cell wall in _mazeWalls)
            {
                if (wall.getRow() == row && wall.getColumn() == column)
                {
                    wall.setWall(false);
                }
            }
            var toBeRemovedWall = _mazeWalls.Find(wall => !wall.isWall());
            _mazePaths.Add(toBeRemovedWall);
            _mazeWalls.Remove(toBeRemovedWall);
        }

        public Cell[,] mazeGeneration()
        {
            _currentCell = _mazePaths.ElementAt(0);
            _cellStack.Push(_currentCell);

            do
            {
                _currentCell.setVisited(true);
                Cell neighbourCell = getRandomNeighbour();

                if (neighbourCell != null)
                    removeTheWall(_currentCell, neighbourCell);

                if (neighbourCell != null)
                {
                    _currentCell = neighbourCell;
                    _cellStack.Push(_currentCell);
                }
                else
                {
                    if (_cellStack.Count > 0)
                        _currentCell = _cellStack.Pop();
                }
            } while (_cellStack.Count > 0);

            mazeVisualisation(_maze);
            return _maze;
        }

         public void mazeVisualisation(Cell[,] _maze)
        {
            foreach (Cell wall in _mazeWalls)
            {
                _maze[wall.getRow(), wall.getColumn()] = wall;
            }

            foreach (Cell path in _mazePaths)
            {
                _maze[path.getRow(), path.getColumn()] = path;

            }
        }
    }
}
