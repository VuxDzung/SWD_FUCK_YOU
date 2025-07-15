using Microsoft.EntityFrameworkCore;
using WebMVC_SWD.Components.Books.Models;

namespace WebMVC_SWD.Components.Books.Services
{
    public class BookService : IBookService
    {
        private readonly BookDBContext _context;

        public BookService(BookDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public (bool IsValid, string ErrorMessage) CheckDuplicate(int id, Book updated)
        {
            var inputValidation = ValidateInput(updated);
            if (!inputValidation.IsValid)
                return inputValidation;

            var existing = _context.Books.FirstOrDefault(b => b.Name == updated.Name && b.Author == updated.Author && b.BookId != id);
            if (existing != null)
                return (false, "Duplicate book name and author!");
            return (true, string.Empty);
        }

        public (bool IsValid, string ErrorMessage) ValidateInput(Book book)
        {
            if (book == null)
                return (false, "Book object is null!");
            if (string.IsNullOrWhiteSpace(book.Name))
                return (false, "Book name is required!");
            if (string.IsNullOrWhiteSpace(book.Author))
                return (false, "Author is required!");
            if (book.Price < 0)
                return (false, "Price cannot be negative!");
            if (book.Stock < 0)
                return (false, "Stock cannot be negative!");
            return (true, string.Empty);
        }

        public bool AddBook(Book book)
        {
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

        public (bool IsValid, string ErrorMessage) CheckDuplicateForAdd(Book book)
        {
            var inputValidation = ValidateInput(book);
            if (!inputValidation.IsValid)
                return inputValidation;

            var existing = _context.Books.FirstOrDefault(b => b.Name == book.Name && b.Author == book.Author);
            if (existing != null)
                return (false, "Duplicate book");
            return (true, string.Empty);
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