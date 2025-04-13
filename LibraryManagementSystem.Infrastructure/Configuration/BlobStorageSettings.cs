
namespace LibraryManagementSystem.Infrastructure.Configuration;

public class BlobStorageSettings 
{
    //property name should match with the configuration
    public string ConnectionString { get; set; } = default!;
    public string CoverImageContainerName { get; set; } = default!;


}
