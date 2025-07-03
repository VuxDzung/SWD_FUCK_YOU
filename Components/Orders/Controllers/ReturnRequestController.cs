using Microsoft.AspNetCore.Mvc;
using WebMVC_SWD.Components.Orders.Interfaces;
using WebMVC_SWD.Components.Orders.Services;

namespace WebMVC_SWD.Components.Orders.Controllers
{
	public class ReturnRequestController : Controller
	{
		private readonly IReturnRequest _requestServices;

		public ReturnRequestController()
		{
			_requestServices = new ReturnRequestServices();
		}

		public IActionResult Index()
		{
			var requests = _requestServices.GetAllRequests();
			ViewBag.Requests = requests;
			return View("~/Components/Orders/Views/RequestsListView.cshtml");
		}

		// POST: /ReturnRequest/Accept/5
		[HttpPost]
		public IActionResult Accept(int id)
		{
			_requestServices.AcceptRequest(id);
			return RedirectToAction("Index");
		}

		// POST: /ReturnRequest/Decline/5
		[HttpPost]
		public IActionResult Decline(int id)
		{
			_requestServices.DeclineRequest(id);
			return RedirectToAction("Index");
		}

		// GET: /ReturnRequest/Create
		// [Dung] Call this in Customer's Order detail page
		public IActionResult Create()
		{
			return View("~/Components/Orders/Views/CreateRequest.cshtml");
		}

		// POST: /ReturnRequest/Create
		[HttpPost]
		public IActionResult Create(int orderId, string reason, string note)
		{
			_requestServices.CreateRequest(orderId, reason, note);
			return RedirectToAction("Index");
		}
	}
}
