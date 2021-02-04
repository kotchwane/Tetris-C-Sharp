using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Source
{
	public class Tetromino : Grid
	{

		// TODO : Get rid of list, keeping only listOfPieces?
		private string[] list;
		private readonly Piece[] orientation;
		public int Rows() {
			return orientation[0].Rows();
		}
		public int Columns() {
			return orientation[0].Columns();
		}

		public char CellAt(int row, int col) {
			return orientation[0].CellAt(row, col);
		}

		public static readonly Tetromino T_SHAPE = new Tetromino(
				"....\n" +
				"TTT.\n" +
				".T..\n"
			,
				".T..\n" +
				"TT..\n" +
				".T..\n"
			,
				"....\n" +
				".T..\n" +
				"TTT.\n"
			,
				".T..\n" +
				".TT.\n" +
				".T..\n"
			);


		public Tetromino(params string[] list) {
			this.list = list;
			this.orientation = new Piece[list.Length];
			for (int i = 0; i < list.Length; i++) {
				orientation[i] = new Piece(list[i]);
			}

		}

		public Tetromino RotateRight() {
			string[] args = new string[list.Length];
			Array.Copy(list, 1, args, 0, list.Length - 1);
			args[list.Length - 1] = list[0];
			return new Tetromino(args);
		}

		public Tetromino RotateLeft() {
			string[] args = new string[list.Length];
			Array.Copy(list, 0, args, 1, list.Length - 1);
			args[0] = list[list.Length - 1];
			return new Tetromino(args);

		}

		public override string ToString() {
			return list[0];
		}


		public static string Reverse(string s) {
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}



	}
}