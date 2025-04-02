

using LibraryManagementSystem.Application.Books.Queries.GetAllBooks;
using MediatR;

namespace LibraryManagementSystem.API.Controllers;

[ApiController]
[Route("api/book")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await mediator.Send(new GetAllBooksQuery());
        return Ok(books);
    }
}
