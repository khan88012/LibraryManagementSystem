

using AutoMapper;
using LibraryManagementSystem.Application.Books.Dtos;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQueryHandler(ILogger<GetAllBooksQueryHandler> logger, IMapper mapper, IBookRepository bookRepository) : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all books");
        var books = await bookRepository.GetAllAsync();
        var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);
        return bookDtos;
    }
}
