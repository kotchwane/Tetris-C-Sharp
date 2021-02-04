using System;

namespace Source
{
	public class StringToMatrix
	{
		public char[,] blocks;
		public StringToMatrix(string grid) {
			string[] subs = grid.Split('\n');
			blocks = new char[subs.Length, subs[0].Length];
			for (int row = 0; row < subs.Length; row++) {
				for (int col = 0; col < subs[0].Length; col++) {
					blocks[row, col] = subs[row][col];
				}
			}
		}



	}
}
