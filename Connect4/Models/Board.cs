using System.Linq;
namespace Connect4
{
	public enum ActivePlayer { Yellow = 1, Red = 2 }
	public enum CellStates { Empty = 0, Yellow = ActivePlayer.Yellow, Red = ActivePlayer.Red }

	public class Board
	{
		CellStates[,] defaultGrid = new CellStates[7, 6];

		public CellStates[,] Grid;
		public bool IsActive = true;
		public int Inserts = 0;
		public bool IsValidDimensions = true;
		public ActivePlayer NextPlayer;
		public Matches Match;

		public Board()
		{
			Grid = defaultGrid;

			this.NextPlayer = RefreshPlayer(this.Inserts);
		}

		public Board(int row, int column)
		{
			IsValidDimensions = ((row == 1 && column < 7) || column == 1 || (row < 4 && column < 4)) ? false : true;
			IsActive = IsValidDimensions ? true : false;
			Grid = new CellStates[column, row];
			this.NextPlayer = RefreshPlayer(this.Inserts);
		}

		#region private methods

		private ActivePlayer RefreshPlayer(int inserts)
		{
			return Inserts % 2 == 0 ? ActivePlayer.Yellow : ActivePlayer.Red;
		}

		private bool IsWinner(ActivePlayer player)
		{
			var cellplayer = (CellStates)player;
			Match = new Matches(cellplayer, Grid);

			return Match.HasWinner;
		}

		#endregion

		public void AddPiece(int columnindex, ActivePlayer activeplayer)
		{
			int cellindex = -1;

			for (int row = 0; row < Grid.GetLength(1); row++)
			{
				var cell = Grid[columnindex, row];

				//Find the next available cell
				if (cell != 0)
					continue;

				cellindex = row;
			}

			//If no available cell, do nothing
			if (cellindex < 0)
				return;

			//if the available cell is found
			Grid[columnindex, cellindex] = (CellStates)activeplayer;
			Inserts++;
			NextPlayer = RefreshPlayer(Inserts);

			var foundSpace = Grid.OfType<CellStates>().Any(x => x == 0);
			if (IsWinner(activeplayer) || !foundSpace)
				this.IsActive = false;

		}
	}

}
