
using Azure.Core;
using LibraryManagementSystem.Application.Books.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories;

internal class BookRepository(BookDbContext dbContext) : IBookRepository
{
    public async Task<int> Add(Book book)
    {
        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync();
        return book.BookID;
    }

    public async Task<IEnumerable<Book>> FilterBooks(string? Title, string? Author, string? Genre)
    {
        int? AuthorId = dbContext.Author.FirstOrDefault(a => a.Name == Author)?.AuthorID;
        int? GenreId = dbContext.Genre.FirstOrDefault(g => g.Name == Genre)?.GenreID;

        var query = dbContext.Books.AsQueryable();

        if (!string.IsNullOrEmpty(Title))
            query = query.Where(b => b.Title.Contains(Title));

        if (AuthorId.HasValue)
            query = query.Where(b => b.AuthorID == AuthorId.Value);

        if (GenreId.HasValue)
            query = query.Where(b => b.GenreID == GenreId.Value);

        return await query.ToListAsync();
    }



    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = await dbContext.Books.Include(book => book.Author).Include(book => book.Genre).ToListAsync();
        return books;
    }
}
