using NewspaperPrinter.Models.Interfaces;
using System.Collections.Generic;

namespace NewspaperPrinter.Models.Concrete
{
    public class Newspaper
    {
        public List<Page> Pages { get; set; }
        public int NoOfCols { get; set; }
        public int NoOfRows { get; set; }
        public int WidthOfPage { get; set; }
        public int NoOfPages { get; set; }
        public NewspaperProperties.ReadabilityLevel readabilityLevel { get; set; }
        public void printNewspaper(IStreamWriter streamWriter)
        {
            for (int i = 0; i < Pages.Count; i++)
            {
                Pages[i].printPage(streamWriter);
            }
        }
    }
}