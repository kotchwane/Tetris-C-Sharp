using System;

namespace Source
{
	public interface Grid {
		 int Rows();
		 int Columns();
		 char CellAt(int row, int col);
	
	}
}