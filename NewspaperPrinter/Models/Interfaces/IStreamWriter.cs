using System;

namespace NewspaperPrinter.Models.Interfaces
{
    public interface IStreamWriter
    {
        void setPath(String filePath);
        void write(String message);
        void writeLine(String message);
    }
}
