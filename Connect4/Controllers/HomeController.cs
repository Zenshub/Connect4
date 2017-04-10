using System.Web.Mvc;

namespace Connect4.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index(int? columnindex)
		{
			Board board = new Board();
			if (Session.Count == 0)
			{
				Session["Model"] = board;
			}
			else
			{
				board = Session["Model"] as Board;
				if (columnindex >= 0)
					AddPiece(board, (int)columnindex);
			}
			return View("Index", board);
		}

		private void AddPiece(Board board, int columnindex)
		{
			if (!board.IsActive)
				return;

			board.AddPiece(columnindex, board.NextPlayer);
		}

		[HttpPost]
		public ActionResult Restart(int? row, int? column)
		{
			Session.Clear();
			ModelState.Clear();
			if (row > 0 && column > 0)
			{
				Board board = new Board((int)row, (int)column);
				Session.Add("Model", board);
			}

			return RedirectToAction("");
		}

	}
}

