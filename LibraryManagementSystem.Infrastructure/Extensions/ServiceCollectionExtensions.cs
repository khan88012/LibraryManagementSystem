

using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Configuration;
using LibraryManagementSystem.Infrastructure.Seeders;
using LibraryManagementSystem.Infrastructure.Storage;

namespace LibraryManagementSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
  
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LMSDb");
            services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));  //this lambda function should look like the configuration method we removed from dbcontext class
            services.AddScoped<IBookSeeder, BookSeeder>();

            services.AddScoped<IBookRepository, BookRepository>();

        services.Configure<BlobStorageSettings>(configuration.GetSection("BlobStorage"));
        services.AddScoped<IBlobStorageService, BlobStorageService>();
    }
    
}
