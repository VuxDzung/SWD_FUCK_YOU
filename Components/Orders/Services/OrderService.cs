using WebMVC_SWD.Components.Orders.Models;
namespace WebMVC_SWD.Components.Orders.Services
{
    public class OrderService
    {
        Dictionary<int, String> customerName = new Dictionary<int, string>()
        {
            [1] = "Minhdepzai1",
            [2] = "Minhdepzai2",
            [3] = "Minhdepzai3",
            [4] = "Minhdepzai4",
            [5] = "Minhdepzai5",
            [6] = "Minhdepzai6",
            [7] = "Minhdepzai7",
            [8] = "Minhdepzai8",
            [9] = "Minhdepzai9"
        };
        public List<Order> getOrderList()
        {
            List<Order> orders = 
    //            new List<Order>()
    //        {
    //            new Order(){
    //                OrderId = 1,
    //                CustomerId = 1,
    //                TotalPrice = 100,
    //                Status = "abc",
    //                CreatedAt = DateTime.Now
    //}
    //        };
                OrderDBContext.INS.Orders.ToList();
            return orders;
        }

        public string confirmOrder(int orderId)
        {
            Order order = OrderDBContext.INS.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if(order == null)
            {
                return "Order not found";
            }
            if (!order.Status.Equals("Awaiting Confirmation"))
            {
                return "Order must be Awaiting Confirmation to Confirm";
            }
            order.Status = "Confirmed";
            OrderDBContext.INS.SaveChanges();
            return "Success";
        }
    }
}
