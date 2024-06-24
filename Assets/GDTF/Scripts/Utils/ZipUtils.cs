using System.IO;
using System.IO.Compression;
using UnityEngine;

namespace GDTF.Utils
{
    public static class ZipUtils
    {
        public static bool Unzip(string filePath, string exportPath)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogError("Zip File not found: (file path) " + filePath);
                return false;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                Debug.LogError("Zip File path is empty");
                return false;
            }

            if (!Directory.Exists(exportPath)) Directory.CreateDirectory(exportPath);

            var unZipPathInfo = new DirectoryInfo(exportPath);
            if (!unZipPathInfo.Exists) unZipPathInfo.Create();

            using var zip = ZipFile.OpenRead(filePath);
            foreach (var entry in zip.Entries)
            {
                var entryPath = Path.Combine(exportPath, entry.FullName);
                if (entryPath.EndsWith("/"))
                {
                    Directory.CreateDirectory(entryPath);
                    continue;
                }

                var entryDir = Path.GetDirectoryName(entryPath);
                if (entryDir != null && !Directory.Exists(entryDir))
                {
                    Directory.CreateDirectory(entryDir);
                }

                entry.ExtractToFile(entryPath, true);
            }

            return true;
        }
    }
}
