using System;

namespace Source
{
	public class Piece : Grid
	{
		// TODO : public or not?
		int rows, columns;
		public char[,] blocks;

		public Piece(string s) { // convert a "...\n...\n...\n" string into a matrix
			StringToMatrix s2m = new StringToMatrix(s);
			blocks = s2m.blocks;
			rows = s2m.rows;
			columns = s2m.columns;
		}

		public int Rows() {
			return rows;
        }
		public int Columns() {
			return columns;
        }
		public char CellAt(int row, int col) {
			return blocks[row, col];
        }

        public override string ToString() {
			return StringToMatrix.Inverse(blocks, Rows(), Columns());
        }
    }
}
