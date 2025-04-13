

using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.UploadCoverImage;

public class UploadBookCoverImageCommand : IRequest<bool>
{
    public int BookId { get; set; }
    public string FileName { get; set; } = default!;
    public Stream File { get; set; } = default!;
}
