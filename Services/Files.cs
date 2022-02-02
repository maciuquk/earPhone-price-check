using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarPhonePriceCheck.Services
{
    class Files
    {
        public static void FolderAndFile(string directoryPath, string filePath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                File.Create(filePath);
            }
        }

        public static string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static void AddCurrentPrice(int currentPrice, string filePath)
        {
            File.AppendAllText(filePath, currentPrice.ToString() + ";");
        }
    }
}
