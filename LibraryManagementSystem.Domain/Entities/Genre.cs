

namespace LibraryManagementSystem.Domain.Entities;

public class Genre
{
    public int GenreID { get; set; }
    public string Name { get; set; } = default!;

    public List<Book> Books { get; set; } = new();
}
