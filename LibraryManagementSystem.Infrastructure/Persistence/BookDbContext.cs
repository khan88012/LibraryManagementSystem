
namespace LibraryManagementSystem.Infrastructure.Persistence;
internal class BookDbContext(DbContextOptions<BookDbContext> options) : DbContext(options)
{
    internal DbSet<Book> Books { get; set; }

    public DbSet<Author> Author { get; set; }

    public DbSet<Genre> Genre { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)  
            .WithMany(a => a.Books) 
            .HasForeignKey(b => b.AuthorID) 
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Genre)  
            .WithMany(g => g.Books) 
            .HasForeignKey(b => b.GenreID) 
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
