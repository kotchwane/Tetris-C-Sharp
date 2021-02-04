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
		private Grid inner;
		
		// position of the top-left case of MovableGrid on Board
		private int row_position_on_grid; // row position of the top left cell of the movableGrid on the board
		private int col_position_on_grid; // col position of top left cell

		private Board board;

		public int Rows() {
			return inner.Rows();
        }
		public int Columns() {
			return inner.Columns();
        }

		public char CellAt(int row, int col) {
			return inner.CellAt(row,col);
        }

		public MovableGrid(Grid inner, Board board) {
			this.inner = inner;
			this.board = board;
			this.row_position_on_grid = -Rows() + 1;
			this.col_position_on_grid = (board.Columns() - Columns()) / 2;
		}

		public override String ToString() {
			return inner.ToString();
		}

	}
}