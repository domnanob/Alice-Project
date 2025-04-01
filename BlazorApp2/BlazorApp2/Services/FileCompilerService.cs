
using System.Diagnostics;

namespace BlazorApp2.Services
{
    public class FileCompilerService : IFileCompilerService
    {
        private const string csc_path = "C:\\Windows\\Microsoft.NET\\Framework\\v3.5\\csc.exe";
        public async Task<string> ExecuteCommand(string filepath, string filename, string[]? param)
        {
            try
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                        RedirectStandardError = true,
                        FileName = "cmd.exe",
                        Arguments = $"/c cd {filepath} && {csc_path} {filename}.cs && {filename}.exe",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                proc.Start();
                foreach (var item in param)
                {
                    proc.StandardInput.WriteLine(item);
                }
                string result = proc.StandardOutput.ReadToEnd();
                proc.Close();
                return result;
            }
            catch (Exception e)
            {
                return "ExecuteCommandSync failed" + e.Message;
            }
        }
    }
}
