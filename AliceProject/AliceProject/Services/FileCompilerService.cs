using System.Diagnostics;

namespace AliceProject.Services
{
    public class FileCompilerService : IFileCompilerService
    {
        private string csc_path => getCSCPath();

        private string getCSCPath() {
            string v3 = "C:\\Windows\\Microsoft.NET\\Framework\\v3.5\\csc.exe";
            string v4 = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\csc.exe"; //uj windowsos
            if (File.Exists(v4))
            {
                return v4;
            }
            else { 
                return v3;
            }
        }
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
