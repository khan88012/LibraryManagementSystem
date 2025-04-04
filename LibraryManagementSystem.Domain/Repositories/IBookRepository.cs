

namespace LibraryManagementSystem.Domain.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> FilterBooks(string? Title, string? Author, string? Genre);
    Task<IEnumerable<Book>> GetAllAsync();

    Task<int> Add(Book book);
    Task<Book> GetByIdAsync(int id);
    Task Delete(Book book);
 
    Task SaveChanges();
}
