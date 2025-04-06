

using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Exceptions;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(ILogger<DeleteBookCommandHandler> logger, IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting book with id : {request.Id}");
        var book = await bookRepository.GetByIdAsync(request.Id);
        if (book == null)
        {
            throw new NotFoundException(nameof(Book).ToString(), request.Id.ToString());
        }
        await bookRepository.Delete(book);
    }
}
