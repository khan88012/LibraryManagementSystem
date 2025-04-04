

using LibraryManagementSystem.Application.Books.Queries.GetAllBooks;
using LibraryManagementSystem.Application.Books.Queries.SearchBook;
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

    [HttpGet("search")]
    public async Task<IActionResult> SearchBooks([FromQuery] string? title, [FromQuery] string? author, [FromQuery] string? genre)
    {
        var query = new SearchBookQuery { Title = title, Author = author, Genre = genre };
        var books = await mediator.Send(query);
        return Ok(books);
    }
}
