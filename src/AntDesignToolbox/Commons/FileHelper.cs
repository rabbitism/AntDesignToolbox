using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.Commons
{
    internal static class FileHelper
    {
        public static async Task CreateTextFileAsync(string path, string content)
        {
            using var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, bufferSize: 4096, useAsync: true);
            using StreamWriter sw = new(stream);
            await sw.WriteAsync(content);
        }

        public static async Task ThrowIfExistAsync(string path)
        {
            if (File.Exists(path))
            {
                await VS.MessageBox.ShowErrorAsync("File already exists. ");
            }
        }
    }
}
