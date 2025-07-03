using Microsoft.AspNetCore.Mvc;

namespace WebMVC_SWD.Components.Orders.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
