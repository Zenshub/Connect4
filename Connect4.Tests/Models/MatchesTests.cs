using System;
using NUnit.Framework;

namespace Connect4.Tests
{
	public class MatchesTests
	{
		CellStates[,] Grid;

		[SetUp]
		public void InitialiseGrid()
		{
			Grid = new CellStates[6, 7];
		}

		[Test]
		public void Draw_WhenNoWinner()
		{
			Grid = new CellStates[6, 7]{
				{CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red}
			};
			Matches match = new Matches(CellStates.Yellow, Grid);
			Assert.IsTrue(match.HasWinner == false);
		}

		[Test]
		public void YellowWon_Horizontal()
		{

			Grid[2, 3] = Grid[3, 3] = Grid[4, 3] = Grid[5, 3] = CellStates.Yellow; ;
			Matches match = new Matches(CellStates.Yellow, Grid);
			var result = match.HasWinner && match.Winner == "Yellow";
			Assert.AreEqual(true, result);
		}

		[Test]
		public void RedWon_Vertical()
		{
			Grid[2, 3] = Grid[2, 4] = Grid[2, 5] = Grid[2, 2] = CellStates.Red; ;
			Matches match = new Matches(CellStates.Red, Grid);
			var result = match.HasWinner && match.Winner == "Red";
			Assert.AreEqual(true, result);
		}

		[Test]
		public void YellowWon_Diagonal()
		{
			Grid[1, 2] = Grid[2, 3] = Grid[3, 4] = Grid[4, 5] = CellStates.Yellow; ;
			Matches match = new Matches(CellStates.Yellow, Grid);
			var result = match.HasWinner && match.Winner == "Yellow";
			Assert.AreEqual(true, result);
		}

		[Test]
		public void RedWon_Diagonal()
		{
			Grid[1, 5] = Grid[2, 4] = Grid[3, 3] = Grid[4, 2] = CellStates.Red; ;
			Matches match = new Matches(CellStates.Red, Grid);
			var result = match.HasWinner && match.Winner == "Red";
			Assert.AreEqual(true, result);
		}

		[TearDown]
		public void CleanUp()
		{
			Grid = null;
		}
	}
}
