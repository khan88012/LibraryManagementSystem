

namespace LibraryManagementSystem.Domain.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> FilterBooks(string? Title, string? Author, string? Genre);
    public Task<IEnumerable<Book>> GetAllAsync();
}
