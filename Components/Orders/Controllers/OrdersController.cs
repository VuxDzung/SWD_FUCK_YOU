using Microsoft.AspNetCore.Mvc;
using WebMVC_SWD.Components.Orders.Services;

namespace WebMVC_SWD.Components.Orders.Controllers
{
    public class OrdersController : Controller
    {
        private OrderService orderService = new OrderService();
        private void Start()
        {
            ViewBag.Message = "";
            ViewBag.Orders = orderService.getOrderList();
        }
        public IActionResult ViewOrders()
        {
            Start();
            return View();
        }

        public IActionResult ConfirmOrders(int orderId)
        {
            Start();
            String message = orderService.confirmOrder(orderId);
            ViewBag.Message = message;
            return View("Index");
        }
    }
}
