

namespace LibraryManagementSystem.Domain.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadBlobAsync(Stream data, string fileName);
}
