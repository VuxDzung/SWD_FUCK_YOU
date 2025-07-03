using Microsoft.AspNetCore.Mvc;
using WebMVC_SWD.Components.Books.Models;
using WebMVC_SWD.Components.Books.Services;

namespace WebMVC_SWD.Components.Books.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;

        public BookController(BookService bookService, CategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("Book/AddBook")]
        public IActionResult AddBook()
        {
            ViewBag.Categories = _categoryService.GetCategorySelectList();
            return View(); // Tự động tìm Views/Book/AddBook.cshtml
        }

        [HttpPost]
        [Route("Book/AddBook")]
        public IActionResult AddBook(Book book)
        {
            ViewBag.Categories = _categoryService.GetCategorySelectList();

            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Invalid input!";
                return View(book); // Tự động tìm đúng View
            }

            var result = _bookService.AddBook(book);

            if (!result)
            {
                ViewBag.ErrorMessage = "Duplicate book name!";
            }
            else
            {
                ViewBag.SuccessMessage = "Book added successfully!";
            }

            return View(book);
        }

        [HttpGet]
        [Route("Book/List")]
        public IActionResult ListBooks()
        {
            var books = _bookService.GetAllBooks();
            return View(books); // View: Views/Book/ListBooks.cshtml
        }

        [HttpGet]
        [Route("Book/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookService.SoftDeleteBook(id);
            return RedirectToAction("ListBooks");
        }

        [HttpGet]
        [Route("Book/Update/{id}")]
        public IActionResult Update(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();

            ViewBag.Categories = _categoryService.GetCategorySelectList();
            return View("UpdateBook", book); // view mới
        }

        [HttpPost]
        [Route("Book/Update/{id}")]
        public IActionResult Update(int id, Book updatedBook)
        {
            ViewBag.Categories = _categoryService.GetCategorySelectList();

            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Invalid input!";
                return View("UpdateBook", updatedBook);
            }

            var result = _bookService.UpdateBook(id, updatedBook);
            if (!result)
            {
                ViewBag.ErrorMessage = "Update failed!";
            }
            else
            {
                ViewBag.SuccessMessage = "Book updated successfully!";
            }

            return View("UpdateBook", updatedBook);
        }


    }
}
