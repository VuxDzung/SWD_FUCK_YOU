using WebMVC_SWD.Components.Orders.Models;

namespace WebMVC_SWD.Components.Orders.Interfaces
{
	public interface IReturnRequest
	{
		public List<ReturnRequest> GetAllRequests();
		public void CreateRequest(int orderId, string reason, string note = null);
		public bool AcceptRequest(int requestId);
		public bool DeclineRequest(int requestId);
	}
}