using System;
using NUnit.Framework;
using System.Web.Mvc;
using System.Reflection;
namespace Connect4.Tests
{
	[TestFixture]
	public class MethodsTests
	{
		Board board;

		[SetUp]
		public void Initialise()
		{
			board = new Board();
		}

		[Test]
		public void Invalid_BoardDimensions()
		{
			board = new Board(3, 3);
			var expected = false;
			Assert.AreEqual(expected, board.IsValidDimensions);
		}

		[Test]
		public void Draw_WhenNoWinner()
		{
			board = new Board(6, 7);
			board.Grid = new CellStates[6, 7]{
				{CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red}
			};
			Matches match = new Matches(CellStates.Yellow, board.Grid);
			Assert.IsTrue(match.HasWinner == false);
		}

		[Test]
		public void YellowWon_Horizontal()
		{
			board.Grid[2, 3] = board.Grid[3, 3] = board.Grid[4, 3] = board.Grid[5, 3] = CellStates.Yellow; ;
			Matches match = new Matches(CellStates.Yellow, board.Grid);
			var result = match.HasWinner && match.Winner == "Yellow";
			Assert.AreEqual(true, result);
		}

		[Test]
		public void RedWon_Vertical()
		{
			board.Grid[2, 3] = board.Grid[2, 4] = board.Grid[2, 5] = board.Grid[2, 2] = CellStates.Red; ;
			Matches match = new Matches(CellStates.Red, board.Grid);
			var result = match.HasWinner && match.Winner == "Red";
			Assert.AreEqual(true, result);
		}

		[Test]
		public void YellowWon_Diagonal()
		{
			board.Grid[1, 2] = board.Grid[2, 3] = board.Grid[3, 4] = board.Grid[4, 5] = CellStates.Yellow; ;
			Matches match = new Matches(CellStates.Yellow, board.Grid);
			var result = match.HasWinner && match.Winner == "Yellow";
			Assert.AreEqual(true, result);
		}

		[Test]
		public void RedWon_Diagonal()
		{
			board.Grid[1, 5] = board.Grid[2, 4] = board.Grid[3, 3] = board.Grid[4, 2] = CellStates.Red; ;
			Matches match = new Matches(CellStates.Red, board.Grid);
			var result = match.HasWinner && match.Winner == "Red";
			Assert.AreEqual(true, result);
		}

		[Test]
		public void InvalidDimensions_BoardInactive_Test()
		{
			board = new Board(1, 6);

			var result = board.IsValidDimensions && board.IsActive;
			Assert.IsFalse(result);
		}

		[TearDown]
		public void CleanUp()
		{

			board = null;
		}
	}
}
