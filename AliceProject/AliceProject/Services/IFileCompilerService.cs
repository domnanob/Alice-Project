namespace AliceProject.Services
{
    public interface IFileCompilerService
    {
        Task<string> ExecuteCommand(string filepath, string filename, string[]? param);
    }
}
