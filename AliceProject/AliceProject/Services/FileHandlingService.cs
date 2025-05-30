﻿using AliceProject.Services;
using Microsoft.AspNetCore.Components.Forms;
using System.IO.Compression;
namespace AliceProject.Services
{
    public class FileHandlingService : IFileHandlingService
    {
        private readonly String[] _usings = ["using System;", "using System.IO;", "using System.Net;", "using System.Linq;", "using System.Text;", "using System.Text.RegularExpressions;", "using System.Collections.Generic;"];
        public async Task CreateFiles(string path, IList<IBrowserFile> files, List<String> NeptunIDs)
        {
            int i = 0;
            foreach (var file in files)
            {
                var filePath = path;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = Path.Combine(filePath, NeptunIDs[i]+ "_" + file.Name);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }
                await CheckFileUsings(filePath);
                i++;
            }
        }
        public async Task<List<String>> CreateFilesFromZip(string path, IList<IBrowserFile> files)
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
                    //1gb limit
                    long maxFileSize = 1L * 1024L * 1024L * 1024L;
                    await file.OpenReadStream(maxAllowedSize: maxFileSize).CopyToAsync(stream);
                }

                //unzip
                ZipFile.ExtractToDirectory(filePath, $"C:\\Temp\\{file.Name.Replace(".zip", "")}", true);
                File.Delete(filePath);

                List<String> filesAdded = new();

                int index = 0;
                foreach (var item in Directory.GetFiles($"C:\\Temp\\{file.Name.Replace(".zip", "")}"))
                {
                    ZipFile.ExtractToDirectory(item, $"C:\\Temp\\{file.Name.Replace(".zip", "")}\\sub{index}");
                    string[] split = item.Split("\\");
                    string neptun = split[split.Length - 1].Split("_")[0].Substring(split[split.Length - 1].Split("_")[0].Length - 6);
                    foreach (var item2 in Directory.GetFiles($"C:\\Temp\\{file.Name.Replace(".zip", "")}\\sub{index}")) {

                        filePath = Path.Combine(path, neptun.ToUpper() + "_Program.cs");
                        File.Copy(item2, filePath);
                        filesAdded.Add(neptun.ToUpper() + "_Program.cs");
                        await CheckFileUsings(filePath);
                    }
                    index++;
                }

                Directory.Delete($"C:\\Temp\\{file.Name.Replace(".zip", "")}",true);
                return filesAdded;
            }
            return new();

        }
        private async Task CheckFileUsings(string path)
        {
            List<string> filedata = await ReadFileContentRaw(path);
            bool changed = false;
            foreach (var file in _usings) {
                if (!filedata.Contains(file)) {
                    List<string> new_filedata = ["/*-- Auto Generated By Alice --*/",file, .. filedata];
                    filedata = new_filedata;
                    changed = true;
                }
            }
            if (changed)
            {
                StreamWriter sw = new StreamWriter(path,false);
                foreach (var file in filedata) {
                    sw.WriteLine(file);
                }
                sw.Close();
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
