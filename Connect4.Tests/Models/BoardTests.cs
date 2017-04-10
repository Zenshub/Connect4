using System;
using NUnit.Framework;

namespace Connect4.Tests
{
	public class BoardTests
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
		public void InvalidDimensions_BoardInactive_Test()
		{
			board = new Board(1, 6);

			var result = board.IsValidDimensions && board.IsActive;
			Assert.IsFalse(result);
		}

		[Test]
		public void Board_WhenNoSpaceExists_InActive()
		{
			board.Grid = new CellStates[6, 7]{
				{CellStates.Empty,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red}
			};
			board.AddPiece(0, ActivePlayer.Yellow);
			Assert.IsFalse((board.IsActive));
		}

		[Test]
		public void AddPiece_Red_WhenNoSpaceExists_NotAdded()
		{
			board.Grid = new CellStates[6, 7]{
				{CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red}
			};
			var temp = board;
			board.AddPiece(1, ActivePlayer.Red);
			var result = temp == board;
			Assert.IsTrue((result));
		}

		[Test]
		public void AddPiece_Red_WhenSpaceExists_RedAdded()
		{
			board.Grid = new CellStates[3, 5]{
				{CellStates.Empty,CellStates.Empty,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
			};
			board.AddPiece(1, ActivePlayer.Red);
			var result = board.Grid[1, 0] == CellStates.Red;
			Assert.IsTrue((result));
		}

		[Test]
		public void AddPiece_Red_WhenSpaceExists_NextPlayerIsYellow()
		{
			board.Grid = new CellStates[3, 5]{
				{CellStates.Empty,CellStates.Empty,CellStates.Yellow,CellStates.Red,CellStates.Yellow},
				{CellStates.Red,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
				{CellStates.Yellow,CellStates.Yellow,CellStates.Red,CellStates.Yellow,CellStates.Red},
			};
			board.AddPiece(1, ActivePlayer.Red);
			var result = board.NextPlayer == ActivePlayer.Yellow;
			Assert.IsTrue((result));
		}

		[TearDown]
		public void CleanUp()
		{

			board = null;
		}
	}
}
