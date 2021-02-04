using System;

namespace Source
{
	public class StringToMatrix
	{
		public char[,] blocks;
		public int rows, columns;

		public StringToMatrix(string shape) {// convert a "...\n...\n...\n" string into a matrix
			string[] lines = shape.Split('\n');
			int Nrows = lines.Length - 1; // because the string finishes with \n, so split finishes with an empty []
			blocks = new char[Nrows, lines[0].Length];

			for (int row = 0; row < Nrows; row++) {
				for (int col = 0; col < lines[0].Length; col++) {
					blocks[row, col] = lines[row][col];
				}
			}
		}


		static public string Inverse(char[,] matrix, int rows, int columns) {
			string grid = "";
			for (int r = 0; r < rows; r++) {
				for (int c = 0; c < columns; c++) {
					grid += matrix[r, c];
				}
				grid += '\n';
			}
			return grid;
		}
	}
}

