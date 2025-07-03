using Microsoft.EntityFrameworkCore;
using WebMVC_SWD.Components.Books.Models;

namespace WebMVC_SWD.Components.Books.Services
{
    public class BookService
    {
        private readonly BookDBContext _context;

        public BookService(BookDBContext context)
        {
            _context = context;
        }

        public bool AddBook(Book book)
        {
            // Check duplicate
            var existing = _context.Books.FirstOrDefault(b => b.Name == book.Name);
            if (existing != null)
                return false;

            _context.Books.Add(book);
            _context.SaveChanges();
            return true;
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Category)
                .Where(b => b.IsActive)
                .ToList();
        }

        public bool SoftDeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return false;

            book.IsActive = false;
            _context.SaveChanges();
            return true;
        }

        public Book? GetBookById(int id)
        {
            return _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.BookId == id && b.IsActive);
        }


        public bool UpdateBook(int id, Book updated)
        {
            var existing = _context.Books.Find(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Author = updated.Author;
            existing.Price = updated.Price;
            existing.Isbn = updated.Isbn;
            existing.Publisher = updated.Publisher;
            existing.PublicationYear = updated.PublicationYear;
            existing.Stock = updated.Stock;
            existing.Description = updated.Description;
            existing.CategoryId = updated.CategoryId;
            _context.SaveChanges();
            return true;
        }

    }
}
