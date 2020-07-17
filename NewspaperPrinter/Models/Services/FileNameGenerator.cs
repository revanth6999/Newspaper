using System;
using System.Linq;

namespace NewspaperPrinter.Models.Services
{
    public class FileNameGenerator
    {
        private static Random random = new Random();
        public static string getName(int length)
        {
            const String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] array = Enumerable.Repeat(characters, length).Select(str => str[random.Next(str.Length)]).ToArray();
            return new String(array);
        }
    }
}
