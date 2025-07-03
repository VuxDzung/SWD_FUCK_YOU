using Microsoft.EntityFrameworkCore;
using WebMVC_SWD.Components.Orders.Interfaces;
using WebMVC_SWD.Components.Orders.Models;

namespace WebMVC_SWD.Components.Orders.Services
{
	public class ReturnRequestServices : IReturnRequest
	{
		private readonly OrderDBContext _context;
		public ReturnRequestServices()
		{
			_context = new OrderDBContext();
		}

		public bool AcceptRequest(int requestId)
		{
			ReturnRequest request = _context.ReturnRequests.FirstOrDefault(r => r.ReturnId == requestId);
			if (request != null)
			{
				request.Status = "Approved";
				return true;
			}
			return false;
		}

		public bool DeclineRequest(int requestId)
		{
			ReturnRequest request = _context.ReturnRequests.FirstOrDefault(r => r.ReturnId == requestId);	
			if (request != null)
			{
				request.Status = "Rejected";
				return true;
			}
			return false;
		}

		public void CreateRequest(int orderId, string reason, string note = null)
		{
			ReturnRequest request = new ReturnRequest();
			request.OrderId = orderId;
			request.Reason = reason;
			request.Note = note;
			request.RequestDate = DateTime.Now;
			request.Status = "Pending";
		}

		public List<ReturnRequest> GetAllRequests()
		{
			return _context.ReturnRequests.Include(r => r.Order).ToList();
		}
	}
}
