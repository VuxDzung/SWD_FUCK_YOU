using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using WebMVC_SWD.Components.Accounts.Models;
using WebMVC_SWD.Components.Books.Models;
using WebMVC_SWD.Components.DiscountBooks.Models;
using WebMVC_SWD.Components.Orders.Models;
using WebMVC_SWD.Components.ReturnRequests.Models;
namespace WebMVC_SWD
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();
            //builder.Services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.ViewLocationFormats.Clear();
            //    options.ViewLocationFormats.Add("/Components/{1}/Views/{0}.cshtml");
            //});

            #region Add Services
            builder.Services.AddDbContext<AccountDBContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

			builder.Services.AddDbContext<BookDBContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

			builder.Services.AddDbContext<DiscountBookDBContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

			builder.Services.AddDbContext<OrderDBContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

			//builder.Services.AddScoped<IBookServices, BookServices>();
			//builder.Services.AddScoped<IOrderServices, OrderServices>();
			#endregion

			#region Configuration
			builder.Services.Configure<RazorViewEngineOptions>(options =>
			{
				options.ViewLocationFormats.Clear();
				options.ViewLocationFormats.Add("/Components/{1}/Views/{0}.cshtml");
				options.ViewLocationFormats.Add("/Components/Shared/Views/{0}.cshtml");
				options.ViewLocationFormats.Add("/Shared/Views/{0}.cshtml");
			});
			#endregion

			var app = builder.Build();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Book}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
