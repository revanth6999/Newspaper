namespace NewspaperPrinter.Models.Concrete
{
    public class NewspaperProperties
    {
        public enum ReadabilityLevel
        {
            High = 2,
            Medium,
            Low,
        }
        public int NoOfCols { get; set; }
        public int NoOfRows { get; set; }
        public int WidthOfPage { get; set; }
        public int WidthOfRow { get; set; }
        public int ColumnSpacing { get; set; }
        public ReadabilityLevel readabilityLevel { get; set; }

    }
}