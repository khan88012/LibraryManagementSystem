
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Exceptions;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(ILogger<UpdateBookCommandHandler> logger, IBookRepository bookRepository, IMapper mapper) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating book with id : {request.id}");
        var book = await bookRepository.GetByIdAsync(request.id);
        if (book == null)
        {
            throw new NotFoundException(nameof(Book).ToString(), request.id.ToString());
        }
        mapper.Map(request, book);
        await bookRepository.SaveChanges();
    }
}

