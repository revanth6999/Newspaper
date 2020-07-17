using System;
using System.IO;

namespace NewspaperFormatter.Models.Interfaces
{
    public interface IStreamReader
    {
        void setPath(String filePath);
        string read();
    }
}
