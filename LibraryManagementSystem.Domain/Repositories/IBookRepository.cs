

namespace LibraryManagementSystem.Domain.Repositories;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllAsync();
}
