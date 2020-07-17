namespace NewspaperFormatter.Models.Concrete
{
    public class NewspaperProperties
    {
        private int _noOfCols;
        private int _noOfRows;
        private int _widthOfPage;
        private int _widthOfRow;
        private int _columnSpacing;
        private ReadabilityLevel _readabilityLevel;
        public enum ReadabilityLevel
        {
            High = 2,
            Medium,
            Low,
        }
        public int NoOfCols { get { return _noOfCols; } set { _noOfCols = value; } }
        public int NoOfRows { get { return _noOfRows; } set { _noOfRows = value; } }
        public int WidthOfPage { get { return _widthOfPage; } set { _widthOfPage = value; } }
        public int WidthOfRow { get { return _widthOfRow; } set { _widthOfRow = value; } }
        public int ColumnSpacing { get { return _columnSpacing; } set { _columnSpacing = value; } }
        public ReadabilityLevel readabilityLevel { get { return _readabilityLevel; } set { _readabilityLevel = value; } }
        public NewspaperProperties(int noOfCols = 3, int noOfRows = 20, int widthOfPage = 80, ReadabilityLevel readabilityLevel = ReadabilityLevel.Medium, int columnSpacing = 3)
        {
            NoOfCols = noOfCols;
            NoOfRows = noOfRows;
            WidthOfPage = widthOfPage;
            WidthOfRow = (WidthOfPage - (NoOfCols + 1) * columnSpacing) / NoOfCols;
            ColumnSpacing = columnSpacing;
            this.readabilityLevel = readabilityLevel;
        }
    }
}