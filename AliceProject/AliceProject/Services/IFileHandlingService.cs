using Microsoft.AspNetCore.Components.Forms;

namespace AliceProject.Services
{
    public interface IFileHandlingService
    {
        Task CreateFiles(string path, IList<IBrowserFile> files, List<String> NeptunIDs);
        Task<List<String>> CreateFilesFromZip(string path, IList<IBrowserFile> files);
        Task CreateTestFile(string path, IList<IBrowserFile> files);
        Task RemoveFile(string path, string filename);
        Task RemoveFiles(string path, IList<IBrowserFile> files);
        Task RemoveAllFiles(string path);
        Task<List<string>> ReadFiles(string path);
        Task<string> ReadFileContentFormatted(string path);
        Task<List<string>> ReadFileContentRaw(string path);

    }
}
