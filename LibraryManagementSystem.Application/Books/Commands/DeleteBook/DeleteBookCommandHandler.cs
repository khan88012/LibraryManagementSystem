

using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(ILogger<DeleteBookCommandHandler> logger, IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, bool>
{
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting book with id : {request.Id}");
        var book = await bookRepository.GetByIdAsync(request.Id);
        if (book == null)
        {
            return false;
        }
        await bookRepository.Delete(book);
        return true;
    }
}
