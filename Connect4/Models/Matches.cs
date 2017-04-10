namespace Connect4
{
	public class Matches
	{
		public bool HasWinner = false;
		public string Winner = string.Empty;

		public Matches(CellStates player, CellStates[,] grid)
		{
			HasWinner = IfIsWinner(player, grid);
			Winner = HasWinner ? player.ToString() : string.Empty;
		}

		public bool IfIsWinner(CellStates player, CellStates[,] grid)
		{
			var _TotalRows = grid.GetLength(1);
			var _TotalColumns = grid.GetLength(0);

			if (player == 0)
				return false;

			// horizontalCheck 
			for (int j = 0; j < _TotalRows - 3; j++)
			{
				for (int i = 0; i < _TotalColumns; i++)
				{
					if (grid[i, j] == player && grid[i, j + 1] == player && grid[i, j + 2] == player && grid[i, j + 3] == player)
					{
						return true;
					}
				}
			}
			// verticalCheck
			for (int i = 0; i < _TotalColumns - 3; i++)
			{
				for (int j = 0; j < _TotalRows; j++)
				{
					if (grid[i, j] == player && grid[i + 1, j] == player && grid[i + 2, j] == player && grid[i + 3, j] == player)
					{
						return true;
					}
				}
			}
			// ascendingDiagonalCheck 
			for (int i = 3; i < _TotalColumns; i++)
			{
				for (int j = 0; j < _TotalRows - 3; j++)
				{
					if (grid[i, j] == player && grid[i - 1, j + 1] == player && grid[i - 2, j + 2] == player && grid[i - 3, j + 3] == player)
						return true;
				}
			}
			// descendingDiagonalCheck
			for (int i = 3; i < _TotalColumns; i++)
			{
				for (int j = 3; j < _TotalRows; j++)
				{
					if (grid[i, j] == player && grid[i - 1, j - 1] == player && grid[i - 2, j - 2] == player && grid[i - 3, j - 3] == player)
						return true;
				}
			}
			return false;
		}
	}
}

