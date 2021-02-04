using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board:Grid
    {
        int rows;
        int columns;
        char[,] board;
        private MovableGrid fallingBlock = null;

        public static readonly char EMPTY = '.';

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.board = new char[rows, columns];

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < columns; c++) {
                    board[r, c] = EMPTY;
                }
            }

        }

        public override String ToString() {
            char[,] curr_board = new char[Rows(), Columns()];
            for (int r = 0; r < Rows(); r++) {
                for (int c = 0; c < Columns(); c++) {
                    if ((fallingBlock is object) && fallingBlock.IsAt(r, c))
                        curr_board[r, c] = fallingBlock.CellAt(r, c);
                    else
                        curr_board[r, c] = board[r, c];

                }
            }

            return StringToMatrix.Inverse(curr_board, Rows(), Columns());
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
            int r = StartingRowOffset(drop);
            fallingBlock = new MovableGrid(drop, this).MoveTo(r, Columns()/2 - drop.Columns()/2);
        }

        static int StartingRowOffset(Grid shape) {
            for (int r = 0; r < shape.Rows(); r++) {
                for (int c = 0; c < shape.Columns(); c++) {
                    if (shape.CellAt(r, c) != EMPTY)
                        return -r;
                }
            }
            return 0;
        } 
      

        public void Tick() {
            MoveDown();
        }

        bool ConflictsWithBoard(MovableGrid block) {
            return block.OutsideBoard() || block.HitsAnotherBlock();
        }

        void StopFallingBlock() {
            CopyToBoard(fallingBlock);
            fallingBlock = null;
        }

        void CopyToBoard(MovableGrid block) {
            for (int r = 0; r < Rows(); r ++) {
                for (int c = 0; c < Columns(); c++) {
                    if (block.IsAt(r, c))
                        board[r, c] = block.CellAt(r, c);
                }
            }

        }


        void RemoveFullRows() {
            RemoveRows(FindFullRows());
        }
        void RemoveRows(List<int> rows) {
            foreach (int idx in rows) {
                RemoveRow(idx);
            }
        }

        void RemoveRow(int idx) { // Or SqueezeRow()
            for (int row = idx - 1; row >= 0; row --) {
                for (int col = 0; col < Columns(); col++) {
                    board[row + 1, col] = board[row, col];
                }
            }

        }

        List<int> FindFullRows() {
            List<int> fullRows = new List<int>();
            for (int row = 0; row < Rows(); row++) {
                if (RowIsFull(row))
                    fullRows.Add(row);
            }
            return fullRows;
        }

        bool RowIsFull(int rowIndex) {
            for (int col = 0; col < Columns(); col++) {
                if (board[rowIndex, col] == EMPTY)
                    return false;
            }
            return true;
        }


        public void MoveDown() {
            if (!IsFallingBlock()) return;
            MovableGrid test = fallingBlock.MoveDown();
            if (ConflictsWithBoard(test)) {
                StopFallingBlock();
                RemoveFullRows();
            }
            else {
                fallingBlock = test;
            }
        }

        void TryMove(MovableGrid new_grid) {
            if (!ConflictsWithBoard(new_grid))
                fallingBlock = new_grid;

        }

        void TryRotate(MovableGrid rotated_grid) {
            TryMove(rotated_grid);
        }


        public void MoveLeft() {
            if (!IsFallingBlock())
                return;
            TryMove(fallingBlock.MoveLeft());
        }

        public void MoveRight() {
            if (!IsFallingBlock())
                return;
            TryMove(fallingBlock.MoveRight());
        }

        public void RotateLeft() {
            if (!IsFallingBlock())
                return;
            TryRotate(fallingBlock.RotateLeft());
        }

        public void RotateRight() {
            if (!IsFallingBlock())
                return;
            TryRotate(fallingBlock.RotateRight());
        }

        public int Rows() {
            return rows;
        }
        public int Columns() {
            return columns;
        }

        public char CellAt(int row, int col) {
            return board[row, col];
        }

        public void FromString(string s) {
            StringToMatrix converter = new StringToMatrix(s);
            board = converter.blocks;
            rows = converter.rows;
            columns = converter.columns;

        }

        


    }
}
