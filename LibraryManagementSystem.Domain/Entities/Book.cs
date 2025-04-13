


namespace LibraryManagementSystem.Domain.Entities;

public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; } = default!;
    public int AuthorID { get; set; }
    public int GenreID { get; set; }
    public string ISBN { get; set; } = default!;
    public string Language { get; set; } = default!;
    public string Edition { get; set; } = default!;
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public string ShelfLocation { get; set; } = default!;
    public DateTime AddedDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Available"; // Enum can be used

    // Navigation Properties
    public Author Author { get; set; } = default!;
    public Genre Genre { get; set; } = default!;
    public string? CoverImage { get; set; }
}
