

using AutoMapper;
using LibraryManagementSystem.Application.Books.Dtos;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Queries.SearchBook;

public class SearchBookQueryHandler(IBookRepository bookRepository, ILogger<SearchBookQueryHandler> logger, IMapper mapper) : IRequestHandler<SearchBookQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(SearchBookQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Filter the books");
        var books = await bookRepository.FilterBooks(request.Title, request.Author, request.Genre);
        var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);
        return bookDtos;
    }
}
