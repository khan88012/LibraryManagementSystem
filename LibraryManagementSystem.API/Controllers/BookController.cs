

using LibraryManagementSystem.Application.Books.Commands.AddBook;
using LibraryManagementSystem.Application.Books.Commands.DeleteBook;
using LibraryManagementSystem.Application.Books.Commands.UpdateBook;
using LibraryManagementSystem.Application.Books.Dtos;
using LibraryManagementSystem.Application.Books.Queries.GetAllBooks;
using LibraryManagementSystem.Application.Books.Queries.SearchBook;
using MediatR;

namespace LibraryManagementSystem.API.Controllers;

[ApiController]
[Route("api/book")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var books = await mediator.Send(new GetAllBooksQuery());
        return Ok(books);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks([FromQuery] string? title, [FromQuery] string? author, [FromQuery] string? genre)
    {
        var query = new SearchBookQuery { Title = title, Author = author, Genre = genre };
        var books = await mediator.Send(query);
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
    {
        var bookId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = bookId }, null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        await mediator.Send(new DeleteBookCommand(id));
        return NotFound();

    }
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookCommand command)
    {
        command.id = id;
        await mediator.Send(command);
        return NotFound();

    }
}
