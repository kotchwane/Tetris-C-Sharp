using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board:Grid
    {
        readonly int rows;
        readonly int columns;

        private MovableGrid fallingBlock = null;
        int r, c; // coordinates of falling block
        char[,] array;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.array = new char[rows, columns];

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < columns; col++) {
                    array[row, col] = '.';
                }
            }
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    s += array[row, col];
             
                }
                s += "\n";
            }
            return s;
        }

        public bool IsFallingBlock() {
            return fallingBlock != null;
        }

        void CheckIfFalling() {
            if (this.fallingBlock != null)
                throw new ArgumentException("A block is already falling.");
        }
        public void Drop(Tetromino drop) {
            CheckIfFalling();
            fallingBlock = new MovableGrid(drop, this);
            int startRow = 0, startCol = columns / 2;
            r = startRow;
            c = startCol;
            array[r,c] = drop.CellAt(0,0);
        
        }

        public void Tick() {
            if (fallingBlock == null) return;
      
            if (r == rows - 1 || array[r + 1, c] != '.') {
                fallingBlock = null;
                return;
            }

            array[r, c] = '.';
            array[r + 1, c] = fallingBlock.CellAt(0, 0);
            r++;
        }
        public int Rows() {
            return rows;
        }
        public int Columns() {
            return columns;
        }

        public char CellAt(int row, int col) {
            return array[row, col];
        }


    }
}
