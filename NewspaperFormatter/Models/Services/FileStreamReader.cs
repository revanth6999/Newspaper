using NewspaperFormatter.Models.Interfaces;
using System;
using System.IO;
namespace NewspaperFormatter.Models.Services
{
    public class FileStreamReader : IStreamReader
    {
        private String _filePath;
        public void setPath(string filePath)
        {
            _filePath = filePath;
        }
        public string read()
        {
            FileStream fileStream = new FileStream(_filePath, FileMode.Open);
            String text;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                text = reader.ReadLine();
            }
            return text;
        }


    }
}
