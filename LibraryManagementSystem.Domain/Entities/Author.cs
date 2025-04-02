

namespace LibraryManagementSystem.Domain.Entities;

public class Author
{
    public int AuthorID { get; set; }
    public string Name { get; set; } = default!;
    public string Bio { get; set; } = default!;
    public string Nationality { get; set; } = default!;

    public List<Book> Books { get; set; } = new();
}
