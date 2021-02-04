using System;

namespace Source
{
	public class Piece : Grid
	{
		// TODO : public or not?
		public char[,] matrix;
		public Piece(string s) { // convert a "...\n...\n...\n" string into a matrix
			string[] subs = s.Split('\n');
			int Nrows = subs.Length - 1; // because the string finishes with \n, so split finishes with an empty []
			matrix = new char[Nrows, subs[0].Length];
			for (int row = 0; row < Nrows; row++) {
				for (int col = 0; col < subs[0].Length; col++) {
					matrix[row, col] = subs[row][col];
				}
			}
		}

		public int Rows() {
			return matrix.GetLength(0);
        }
		public int Columns() {
			return matrix.GetLength(1);
        }
		public char CellAt(int row, int col) {
			return matrix[row, col];
        }
	}
}
