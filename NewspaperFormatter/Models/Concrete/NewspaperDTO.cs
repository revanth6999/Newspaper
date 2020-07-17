using System.Collections.Generic;
namespace NewspaperFormatter.Models.Concrete
{
    class NewspaperDTO
    {
        public List<Page> Pages { get; set; }
        public int NoOfCols { get; set; }
        public int NoOfRows { get; set; }
        public int WidthOfPage { get; set; }
        public int NoOfPages { get; set; }
        public NewspaperProperties.ReadabilityLevel readabilityLevel { get; set; }
        public string outFileName { get; set; }
    }
}