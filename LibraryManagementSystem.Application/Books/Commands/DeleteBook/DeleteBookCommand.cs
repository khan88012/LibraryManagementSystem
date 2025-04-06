
using MediatR;

namespace LibraryManagementSystem.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
