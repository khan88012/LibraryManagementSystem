

using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Application.Books.Commands.UploadCoverImage;

public class UploadBookCoverImageCommandHandler(ILogger<UploadBookCoverImageCommandHandler> logger ,
    IBookRepository bookRepository ,
    IBlobStorageService blobStorageService
    ) : IRequestHandler<UploadBookCoverImageCommand , bool>
{
    public async Task<bool> Handle(UploadBookCoverImageCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"UploadBookCoverImageCommand for book with id : {request.BookId}");
        var book = await bookRepository.GetByIdAsync( request.BookId );

        if (book == null)
        {
            return false;
        }

       var imageUrl =  await blobStorageService.UploadBlobAsync(request.File, request.FileName);

        book.CoverImage = imageUrl;
       await bookRepository.SaveChanges();
        return true;

    }
}
