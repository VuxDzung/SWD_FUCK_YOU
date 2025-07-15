using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMVC_SWD.Components.Books.Services
{
    public interface ICategoryService
    {
        SelectList GetCategorySelectList();
    }
}