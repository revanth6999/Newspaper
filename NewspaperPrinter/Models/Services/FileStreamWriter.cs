using NewspaperPrinter.Models.Interfaces;
using System;
using System.IO;

namespace NewspaperPrinter.Models.Services
{
    public class FileStreamWriter : IStreamWriter
    {
        private String _filePath;

        public void setPath(string filePath)
        {
            _filePath = filePath;
        }

        public void write(String message)
        {
            using (StreamWriter streamWriter = File.AppendText(_filePath))
            {
                streamWriter.Write(message);
            }
        }
        public void writeLine(string message)
        {
            using (StreamWriter streamWriter = File.AppendText(_filePath))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
