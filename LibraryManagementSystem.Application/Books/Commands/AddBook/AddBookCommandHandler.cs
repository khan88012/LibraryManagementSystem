
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Commands.AddBook;

public class AddBookCommandHandler(ILogger<AddBookCommandHandler> logger, IMapper mapper, IBookRepository bookRepository) : IRequestHandler<AddBookCommand, int>
{
    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding a book.");
        var book = mapper.Map<Book>(request);
        //int id = await bookRepository.Add(book);
        //return id;
        return 1;
    }
}
