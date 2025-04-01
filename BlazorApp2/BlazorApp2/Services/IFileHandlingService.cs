using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp2.Services
{
    public interface IFileHandlingService
    {
        Task CreateFiles(String path, IList<IBrowserFile> files);
        Task CreateTestFile(String path, IList<IBrowserFile> files);
        Task RemoveFile(string path, string filename);
        Task RemoveFiles(string path, IList<IBrowserFile> files);
        Task RemoveAllFiles(string path);
        Task<List<String>> ReadFiles(String path);
        Task<String> ReadFileContentFormatted(String path);
        Task<List<String>> ReadFileContentRaw(String path);

    }
}
