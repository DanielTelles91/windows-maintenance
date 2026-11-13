using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/**
 *
 * @author Daniel Arantes Telles
 */

namespace Manutenção_Windows.Services
{
    public class SystemCleanupAnalysisService
    {
        public class FolderResult
        {
            public string FolderPath { get; set; }
            public long TotalBytes { get; set; }
            public int FilesFound { get; set; }
            public int FilesSkipped { get; set; }
        }

        public class FolderCleanupResult
        {
            public string FolderPath { get; set; }
            public int FilesDeleted { get; set; }
            public int FilesSkipped { get; set; }
            public int DirectoriesDeleted { get; set; }
            public int DirectoriesSkipped { get; set; }
            public long BytesDeleted { get; set; }
        }

        public class ComponentStoreResult
        {
            public int ExitCode { get; set; }
            public string Output { get; set; }
            public long? ActualSizeBytes { get; set; }
            public long? SharedSizeBytes { get; set; }
            public long? BackupsSizeBytes { get; set; }
            public long? CacheSizeBytes { get; set; }
            public int? ReclaimablePackages { get; set; }
            public bool? CleanupRecommended { get; set; }
            public DateTime? LastCleanupDate { get; set; }
        }

        public static Task<FolderResult> AnalyzeFolderAsync(string folderPath)
        {
            return Task.Run(() => AnalyzeFolder(folderPath));
        }

        public static Task<FolderCleanupResult> CleanFolderAsync(string folderPath)
        {
            return Task.Run(() => CleanFolder(folderPath));
        }

        private static FolderCleanupResult CleanFolder(string folderPath)
        {
            var result = new FolderCleanupResult
            {
                FolderPath = folderPath
            };

            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException(
                    $"A pasta não foi encontrada: {folderPath}");

            // Não permite trabalhar sobre uma pasta raiz que seja um link.
            FileAttributes rootAttributes = File.GetAttributes(folderPath);

            if ((rootAttributes & FileAttributes.ReparsePoint) != 0)
                throw new InvalidOperationException(
                    "A pasta selecionada é um link ou ponto de montagem.");

            var pendingFolders = new Stack<string>();
            var directories = new List<string>();

            pendingFolders.Push(folderPath);

            while (pendingFolders.Count > 0)
            {
                string currentFolder = pendingFolders.Pop();
                directories.Add(currentFolder);

                try
                {
                    foreach (string entry in Directory.EnumerateFileSystemEntries(currentFolder))
                    {
                        try
                        {
                            FileAttributes attributes = File.GetAttributes(entry);

                            // Ignora links simbólicos e pontos de montagem.
                            if ((attributes & FileAttributes.ReparsePoint) != 0)
                                continue;

                            if ((attributes & FileAttributes.Directory) != 0)
                            {
                                pendingFolders.Push(entry);
                            }
                            else
                            {
                                var fileInfo = new FileInfo(entry);
                                long fileSize = fileInfo.Length;

                                File.Delete(entry);

                                result.FilesDeleted++;
                                result.BytesDeleted += fileSize;
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            result.FilesSkipped++;
                        }
                        catch (IOException)
                        {
                            result.FilesSkipped++;
                        }
                        catch (System.Security.SecurityException)
                        {
                            result.FilesSkipped++;
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    result.DirectoriesSkipped++;
                }
                catch (IOException)
                {
                    result.DirectoriesSkipped++;
                }
                catch (System.Security.SecurityException)
                {
                    result.DirectoriesSkipped++;
                }
            }

            // Remove as subpastas de dentro para fora.
            // (A pasta TEMP original é preservada)
            for (int i = directories.Count - 1; i >= 1; i--)
            {
                try
                {
                    Directory.Delete(directories[i], false);
                    result.DirectoriesDeleted++;
                }
                catch (UnauthorizedAccessException)
                {
                    result.DirectoriesSkipped++;
                }
                catch (IOException)
                {
                    result.DirectoriesSkipped++;
                }
                catch (System.Security.SecurityException)
                {
                    result.DirectoriesSkipped++;
                }
            }

            return result;
        }


        private static FolderResult AnalyzeFolder(string folderPath)
        {
            var result = new FolderResult
            {
                FolderPath = folderPath
            };

            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException(
                    $"A pasta não foi encontrada: {folderPath}");

            var folders = new Stack<string>();
            folders.Push(folderPath);

            while (folders.Count > 0)
            {
                string currentFolder = folders.Pop();

                try
                {
                    foreach (string entry in Directory.EnumerateFileSystemEntries(currentFolder))
                    {
                        try
                        {
                            FileAttributes attributes = File.GetAttributes(entry);

                            // Não percorre links simbólicos
                            if ((attributes & FileAttributes.ReparsePoint) != 0)
                                continue;

                            if ((attributes & FileAttributes.Directory) != 0)
                            {
                                folders.Push(entry);
                            }
                            else
                            {
                                var fileInfo = new FileInfo(entry);

                                if (fileInfo.Exists)
                                {
                                    result.TotalBytes += fileInfo.Length;
                                    result.FilesFound++;
                                }
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            result.FilesSkipped++;
                        }
                        catch (IOException)
                        {
                            result.FilesSkipped++;
                        }
                        catch (System.Security.SecurityException)
                        {
                            result.FilesSkipped++;
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    result.FilesSkipped++;
                }
                catch (IOException)
                {
                    result.FilesSkipped++;
                }
                catch (System.Security.SecurityException)
                {
                    result.FilesSkipped++;
                }
            }

            return result;
        }

        public static async Task<ComponentStoreResult> AnalyzeComponentStoreAsync()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "dism.exe",
                Arguments = "/English /Online /Cleanup-Image /AnalyzeComponentStore",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = new Process())
            {
                process.StartInfo = startInfo;

                process.Start();

                Task<string> outputTask = process.StandardOutput.ReadToEndAsync();
                Task<string> errorTask = process.StandardError.ReadToEndAsync();

                await Task.WhenAll(outputTask, errorTask);

                process.WaitForExit();

                string output = outputTask.Result;
                string error = errorTask.Result;

                if (!string.IsNullOrWhiteSpace(error))
                    output += Environment.NewLine + error;

                return ParseComponentStoreOutput(process.ExitCode, output);
            }
        }

        public static async Task<ComponentStoreResult> CleanComponentStoreAsync()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "dism.exe",
                Arguments = "/English /Online /Cleanup-Image /StartComponentCleanup",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                Task<string> outputTask =
                    process.StandardOutput.ReadToEndAsync();

                Task<string> errorTask =
                    process.StandardError.ReadToEndAsync();

                await Task.WhenAll(outputTask, errorTask);

                await Task.Run(() => process.WaitForExit());

                string output = outputTask.Result;
                string error = errorTask.Result;

                if (!string.IsNullOrWhiteSpace(error))
                    output += Environment.NewLine + error;

                return new ComponentStoreResult
                {
                    ExitCode = process.ExitCode,
                    Output = output
                };
            }
        }



        private static ComponentStoreResult ParseComponentStoreOutput(
            int exitCode, string output)
        {
            return new ComponentStoreResult
            {
                ExitCode = exitCode,
                Output = output,

                ActualSizeBytes = FindSize(output,
                    "Tamanho Real do Repositório de Componentes",
                    "Actual Size of Component Store"),

                SharedSizeBytes = FindSize(output,
                    "Compartilhado com o Windows",
                    "Shared with Windows"),

                BackupsSizeBytes = FindSize(output,
                    "Backups e Recursos Desabilitados",
                    "Backups and Disabled Features"),

                CacheSizeBytes = FindSize(output,
                    "Cache e Dados Temporários",
                    "Cache and Temporary Data"),

                ReclaimablePackages = FindInteger(output,
                    "Número de Pacotes Recuperáveis",
                    "Number of Reclaimable Packages"),

                CleanupRecommended = FindBoolean(output,
                    "Limpeza do Repositório de Componentes Recomendada",
                    "Component Store Cleanup Recommended"),

                LastCleanupDate = FindDateTime(output,
    "Date of Last Cleanup",
    "Data da Última Limpeza")
            };
        }



        private static long? FindSize(string output, params string[] labels)
        {
            foreach (string line in output.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string label in labels)
                {
                    if (line.IndexOf(label, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Match match = Regex.Match(
                            line,
                            @"([\d.,]+)\s*(bytes?|B|KB|MB|GB|TB)",
                            RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            string numberText = match.Groups[1].Value.Replace(',', '.');

                            if (double.TryParse(
                                numberText,
                                NumberStyles.Any,
                                CultureInfo.InvariantCulture,
                                out double number))
                            {
                                string unit = match.Groups[2].Value.ToUpperInvariant();

                                double multiplier = 1d;

                                switch (unit)
                                {
                                    case "TB":
                                        multiplier = 1024d * 1024 * 1024 * 1024;
                                        break;

                                    case "GB":
                                        multiplier = 1024d * 1024 * 1024;
                                        break;

                                    case "MB":
                                        multiplier = 1024d * 1024;
                                        break;

                                    case "KB":
                                        multiplier = 1024d;
                                        break;
                                }

                                return (long)(number * multiplier);
                            }
                        }
                    }
                }
            }

            return null;
        }

        private static int? FindInteger(string output, params string[] labels)
        {
            foreach (string line in output.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string label in labels)
                {
                    if (line.IndexOf(label, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Match match = Regex.Match(line, @"\d+");

                        if (match.Success &&
                            int.TryParse(match.Value, out int value))
                            return value;
                    }
                }
            }

            return null;
        }



        private static bool? FindBoolean(string output, params string[] labels)
        {
            foreach (string line in output.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string label in labels)
                {
                    if (line.IndexOf(label, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string valor = line.Substring(
                            line.IndexOf(':') + 1).Trim();

                        if (valor.StartsWith("Sim",
                            StringComparison.OrdinalIgnoreCase) ||
                            valor.StartsWith("Yes",
                            StringComparison.OrdinalIgnoreCase))
                            return true;

                        if (valor.StartsWith("Não",
                            StringComparison.OrdinalIgnoreCase) ||
                            valor.StartsWith("Nao",
                            StringComparison.OrdinalIgnoreCase) ||
                            valor.StartsWith("No",
                            StringComparison.OrdinalIgnoreCase))
                            return false;
                    }
                }
            }

            return null;
        }

        private static DateTime? FindDateTime(string output, params string[] labels)
        {
            foreach (string line in output.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string label in labels)
                {
                    int index = line.IndexOf(
                        label,
                        StringComparison.OrdinalIgnoreCase);

                    if (index >= 0)
                    {
                        int colonIndex = line.IndexOf(':', index + label.Length);

                        if (colonIndex >= 0)
                        {
                            string dateText = line.Substring(colonIndex + 1).Trim();

                            if (DateTime.TryParseExact(
                                dateText,
                                "yyyy-MM-dd HH:mm:ss",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime date))
                            {
                                return date;
                            }
                        }
                    }
                }
            }

            return null;
        }




    }
}
