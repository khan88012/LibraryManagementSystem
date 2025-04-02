

using LibraryManagementSystem.Application.Books.Dtos;
using MediatR;

namespace LibraryManagementSystem.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
{
}
