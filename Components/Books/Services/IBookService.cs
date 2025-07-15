using WebMVC_SWD.Components.Books.Models;

namespace WebMVC_SWD.Components.Books.Services
{
    public interface IBookService
    {
        (bool IsValid, string ErrorMessage) ValidateInput(Book book);
        (bool IsValid, string ErrorMessage) CheckDuplicateForAdd(Book book);
        (bool IsValid, string ErrorMessage) CheckDuplicate(int id, Book updated);
        bool AddBook(Book book);
        List<Book> GetAllBooks();
        bool SoftDeleteBook(int id);
        Book? GetBookById(int id);
        bool UpdateBook(int id, Book updated);
    }
}