using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Source
{

	public class MovableGrid:Grid
	{
		private Tetromino inner;
		private int row; 
		private int col; 
		private Board board;

		public MovableGrid(Tetromino inner, Board board) : this(0, 0, inner, board) { }

		private MovableGrid(int outer_row, int outer_col, Tetromino inner, Board board) {
			this.inner = inner;
			this.board = board;
			this.row = outer_row;
			this.col = outer_col;
		}

		public int Rows() {
			return inner.Rows();
        }
		public int Columns() {
			return inner.Columns();
        }

		int ToInnerRow(int outer_row) {
			return outer_row - row;
        }

		int ToOuterRow(int inner_row) {
			return inner_row + row;
	
        }
		int ToInnerCol(int outer_col) {
			return outer_col - col;
        }

		int ToOuterCol(int inner_col) {
			return inner_col + col;
        }

		public char CellAt(int outer_row, int outer_col) {
			int inner_row = ToInnerRow(outer_row);
			int inner_col = ToInnerCol(outer_col);
			return inner.CellAt(inner_row, inner_col);
        }


		public bool IsAt(int outer_row, int outer_col) {
			int inner_row = ToInnerRow(outer_row);
			int inner_col = ToInnerCol(outer_col);
			return inner_row >= 0
				&& inner_row < inner.Rows()
				&& inner_col >= 0
				&& inner_col < inner.Columns()
				&& inner.CellAt(inner_row, inner_col) != Board.EMPTY;
        }

		
		public MovableGrid MoveTo(int outer_row, int outer_col) {
			return new MovableGrid(outer_row, outer_col, inner, board);
        }

		public MovableGrid MoveLeft() {
			return new MovableGrid(row, col - 1, inner, board);
        }

		public MovableGrid MoveRight() {
            return new MovableGrid(row, col + 1, inner, board);
        }

		public MovableGrid MoveDown() {
			return new MovableGrid(row + 1, col, inner, board);
        }

		public MovableGrid RotateRight() {
			return new MovableGrid(row, col, inner.RotateRight(), board);
        }
		public MovableGrid RotateLeft() {
			return new MovableGrid(row, col, inner.RotateLeft(), board);
        }


		public bool OutsideBoard() {

			for (int r = 0; r < Rows(); r++) {
				for (int c = 0; c < Columns(); c++) {
			
					if (inner.CellAt(r,c) != Board.EMPTY) {
						int outer_row = ToOuterRow(r);
						int outer_col = ToOuterCol(c);
						if (outer_col < 0 || outer_col >= board.Columns() || outer_row < 0 || outer_row >= board.Rows())
							return true;
                    }
                }
            }
			return false;
        }

		public bool HitsAnotherBlock() {
		
			for (int r = 0; r < Rows(); r++) {
				for (int c = 0; c < Columns(); c++) {
					if (inner.CellAt(r,c) != Board.EMPTY) {
						int outer_row = ToOuterRow(r);
						int outer_col = ToOuterCol(c);
						if (board.CellAt(outer_row, outer_col) != Board.EMPTY)
							return true;
                    }
                }
            }
			return false;
        }


		public override String ToString() {
			return inner.ToString();
		}

	}
}