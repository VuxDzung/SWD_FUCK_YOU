using Microsoft.AspNetCore.Mvc;
using WebMVC_SWD.Components.Orders.Interfaces;

namespace WebMVC_SWD.Components.Orders.Controllers
{
	public class ReturnRequestController : Controller
	{
		private readonly IReturnRequest _requestServices;

		/// <summary>
		/// Get all requests
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			
			return View();
		}

		[HttpPost]
		public IActionResult CreateRequest()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AcceptRequest()
		{
			return View();
		}

		[HttpPost]
		public IActionResult DeclineRequest()
		{
			return View();
		}
	}
}
