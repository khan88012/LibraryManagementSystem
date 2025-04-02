
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories;

internal class BookRepository(BookDbContext dbContext) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = await dbContext.Books.Include(book => book.Author).Include(book => book.Genre).ToListAsync();
        return books;
    }
}
