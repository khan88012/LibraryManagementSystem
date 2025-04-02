

namespace LibraryManagementSystem.Application.Books.Dtos;

public class BookDto
{
    public int BookID { get; set; }
    public string Title { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public string Language { get; set; } = default!;
    public string Edition { get; set; } = default!;
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public string ShelfLocation { get; set; } = default!;
    public string Status { get; set; } = "Available";

    public int AuthorID { get; set; }
    public int GenreID { get; set; }
}
