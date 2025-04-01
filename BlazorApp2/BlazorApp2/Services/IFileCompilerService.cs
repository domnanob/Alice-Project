namespace BlazorApp2.Services
{
    public interface IFileCompilerService
    {
        Task<String> ExecuteCommand(string filepath, string filename, string[]? param);
    }
}
