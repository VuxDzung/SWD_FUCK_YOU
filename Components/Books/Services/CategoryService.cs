using WebMVC_SWD.Components.Books.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMVC_SWD.Components.Books.Services
{
    public class CategoryService
    {
        private readonly BookDBContext _context;

        public CategoryService(BookDBContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetCategorySelectList()
        {
            return _context.BookCategories
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                })
                .ToList();
        }
    }
}
