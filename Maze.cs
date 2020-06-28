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
    class Maze
    {

        public static int length = 31;
        private Cell[,] _maze;
        List<Cell> _mazeWalls;
        List<Cell> _mazeCells;
        Cell _currentCell;
        Stack<Cell> _cellStack;

        private Random _rand;
        
        public Cell[,] getMaze()
        {
            return _maze;
        }

        public Maze()
        {
            _mazeCells = new List<Cell>();
            _mazeWalls = new List<Cell>();

            for (var i = 0; i < length; ++i)
            {
                for (var j = 0; j < length; ++j)
                {
                    Cell cell = new Cell(i, j);
                    if (i % 2 == 0 || j % 2 == 0)
                    {
                        cell.setWall(true);
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
            northN = _currentCell.getRow() - 2 > 0 ? _mazeCells.Find(cell => _currentCell.getRow() - 2 == cell.getRow() && _currentCell.getColumn() == cell.getColumn()) : null;
            southN = _currentCell.getRow() + 2 < length - 1 ? _mazeCells.Find(cell => _currentCell.getRow() + 2 == cell.getRow() && _currentCell.getColumn() == cell.getColumn()) : null;
            eastN = _currentCell.getColumn() + 2 < length - 1 ? _mazeCells.Find(cell => _currentCell.getRow() == cell.getRow() && _currentCell.getColumn() + 2 == cell.getColumn()) : null;
            westN = _currentCell.getColumn() - 2 > 0 ? _mazeCells.Find(cell => _currentCell.getRow() == cell.getRow() && _currentCell.getColumn() - 2 == cell.getColumn()) : null;

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
            _mazeCells.Add(toBeRemovedWall);
            _mazeWalls.Remove(toBeRemovedWall);
        }

        public Cell[,] mazeGeneration()
        {
            _currentCell = _mazeCells.ElementAt(0);
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

            return _maze;
        }

         public void mazeVisualisation(Cell[,] _maze)
        {
            foreach (Cell wall in _mazeWalls)
            {
                _maze[wall.getRow(), wall.getColumn()] = wall;
            }

            foreach (Cell cell in _mazeCells)
            {
                _maze[cell.getRow(), cell.getColumn()] = cell;

            }
        }

        public void print(String output)
        {
            mazeVisualisation(_maze);
            if (output == "console")
            {

                for (int i = 0; i < length; ++i)
                {
                    for (int j = 0; j < length; ++j)
                    {
                        Console.Write(_maze[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else 
            {
                using (var writer = File.CreateText(output))
                {
                    for (int i = 0; i < length; ++i)
                    {
                        for (int j = 0; j < length; ++j)
                        {
                            writer.Write(_maze[i, j]);
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
