using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Seeders;

internal class BookSeeder(BookDbContext dbContext) : IBookSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync()) 
        {
            if (!dbContext.Author.Any()) 
            {
                var authors = GetAuthors();
                dbContext.Author.AddRange(authors);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Genre.Any()) 
            {
                var genres = GetGenres();
                dbContext.Genre.AddRange(genres);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Books.Any()) 
            {
                var books = GetBooks();
                dbContext.Books.AddRange(books);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Author> GetAuthors()
    {
        return new List<Author>
        {
            new Author { Name = "F. Scott Fitzgerald", Bio = "American novelist, known for The Great Gatsby.", Nationality = "American" },
            new Author {  Name = "Harper Lee", Bio = "Author of To Kill a Mockingbird.", Nationality = "American" },
            new Author {  Name = "George Orwell", Bio = "British writer known for 1984 and Animal Farm.", Nationality = "British" },
            new Author {  Name = "Herman Melville", Bio = "American writer, best known for Moby-Dick.", Nationality = "American" }
        };
    }

    private IEnumerable<Genre> GetGenres()
    {
        return new List<Genre>
        {
            new Genre {  Name = "Classic" },
            new Genre {  Name = "Fiction" },
            new Genre {  Name = "Dystopian" },
            new Genre {  Name = "Adventure" }
        };
    }

    private IEnumerable<Book> GetBooks()
    {
        return new List<Book>
        {
            new Book
            {
                Title = "The Great Gatsby",
                AuthorID = 1,
                GenreID = 1,
                ISBN = "9780743273565",
                Language = "English",
                Edition = "1st",
                TotalCopies = 5,
                AvailableCopies = 3,
                ShelfLocation = "A1",
                AddedDate = DateTime.UtcNow,
                Status = "Available"
            },
            new Book
            {
                Title = "To Kill a Mockingbird",
                AuthorID = 2,
                GenreID = 2,
                ISBN = "9780061120084",
                Language = "English",
                Edition = "1st",
                TotalCopies = 4,
                AvailableCopies = 2,
                ShelfLocation = "A2",
                AddedDate = DateTime.UtcNow,
                Status = "Borrowed"
            },
            new Book
            {
                Title = "1984",
                AuthorID = 3,
                GenreID = 3,
                ISBN = "9780451524935",
                Language = "English",
                Edition = "1st",
                TotalCopies = 6,
                AvailableCopies = 4,
                ShelfLocation = "A3",
                AddedDate = DateTime.UtcNow,
                Status = "Available"
            },
            new Book
            {
                Title = "Moby-Dick",
                AuthorID = 4,
                GenreID = 4,
                ISBN = "9781503280786",
                Language = "English",
                Edition = "1st",
                TotalCopies = 3,
                AvailableCopies = 1,
                ShelfLocation = "A4",
                AddedDate = DateTime.UtcNow,
                Status = "Borrowed"
            }
        };
    }
}
