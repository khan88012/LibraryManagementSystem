

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LibraryManagementSystem.Infrastructure.Persistence;

public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
{
    BookDbContext IDesignTimeDbContextFactory<BookDbContext>.CreateDbContext(string[] args)
    {
        // 🔧 Build configuration manually
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // 👈 Important for resolving appsettings.json
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("LMSDb");

        var optionsBuilder = new DbContextOptionsBuilder<BookDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new BookDbContext(optionsBuilder.Options);
    }
}
