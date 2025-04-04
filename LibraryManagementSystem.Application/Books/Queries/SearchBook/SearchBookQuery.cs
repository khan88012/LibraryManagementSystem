

using LibraryManagementSystem.Application.Books.Dtos;
using MediatR;

namespace LibraryManagementSystem.Application.Books.Queries.SearchBook;

public class SearchBookQuery : IRequest<IEnumerable<BookDto>>
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
}
