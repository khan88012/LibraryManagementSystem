
using AutoMapper;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(ILogger<UpdateBookCommandHandler> logger, IBookRepository bookRepository, IMapper mapper) : IRequestHandler<UpdateBookCommand, bool>
{
    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating book with id : {request.id}");
        var book = await bookRepository.GetByIdAsync(request.id);
        if (book == null)
        {
            return false;
        }
        mapper.Map(request, book);
        await bookRepository.SaveChanges();
        return true;
    }
}

