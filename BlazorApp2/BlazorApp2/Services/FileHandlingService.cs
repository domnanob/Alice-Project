using BlazorApp2.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp2.Services
{
    public class FileHandlingService : IFileHandlingService
    {
        public async Task CreateFiles(string path, IList<IBrowserFile> files)
        {
            foreach (var file in files)
            {
                var filePath = path;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = Path.Combine(filePath, "Neptunkod" + file.Name);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }
            }
        }
        public async Task CreateTestFile(string path, IList<IBrowserFile> files)
        {
            foreach (var file in files)
            {
                var filePath = path;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = Path.Combine(filePath, file.Name);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }
            }
        }

        public async Task<string> ReadFileContentFormatted(string path)
        {
            string filedata = "";
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                filedata += sr.ReadLine() + "<br>";
            }
            sr.Close();
            return filedata;
        }
        public async Task<List<string>> ReadFileContentRaw(string path)
        {
            List<string> filedata = new();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                filedata.Add(sr.ReadLine());
            }
            sr.Close();
            return filedata;
        }

        public async Task<List<string>> ReadFiles(string path)
        {
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                return files.Select(file => Path.GetFileName(file)).ToList();
            }
            return new();
        }

        public async Task RemoveAllFiles(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        public async Task RemoveFile(string path, string filename)
        {
            if (Directory.Exists(path))
            {
                if (File.Exists(Path.Combine(path, filename)))
                {
                    File.Delete(Path.Combine(path, filename));
                }
            }
        }

        public async Task RemoveFiles(string path, IList<IBrowserFile> files)
        {
            foreach (var file in files)
            {
                var filePath = path;
                if (Directory.Exists(filePath))
                {
                    if (File.Exists(Path.Combine(path, file.Name)))
                    {
                        File.Delete(Path.Combine(path, file.Name));
                    }
                }
            }
        }
    }
}
