using System;
using System.Collections.Generic;

namespace Connect4.Tests
{
	public class BoardComparer : Comparer<Board>
	{
		public override int Compare(Board x, Board y)
		{
			return string.Compare(x.Grid.ToString(), y.Grid.ToString(), StringComparison.Ordinal);
		}
	}
}
