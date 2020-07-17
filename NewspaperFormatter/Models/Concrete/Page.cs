using System.Collections.Generic;

namespace NewspaperFormatter.Models.Concrete
{
    public class Page
    {
        private List<Column> _columns;
        private int _noOfCols;
        private int _noOfRows;
        private int _widthOfPage;
        private int _widthOfRow;
        private int _columnSpacing;
        private NewspaperProperties.ReadabilityLevel _readabilityLevel;
        public List<Column> Columns { get { return _columns; } set { _columns = value; } }
        public int NoOfCols { get { return _noOfCols; } set { _noOfCols = value; } }
        public int NoOfRows { get { return _noOfRows; } set { _noOfRows = value; } }
        public int WidthOfPage { get { return _widthOfPage; } set { _widthOfPage = value; } }
        public int WidthOfRow { get { return _widthOfRow; } set { _widthOfRow = value; } }
        public int ColumnSpacing { get { return _columnSpacing; } set { _columnSpacing = value; } }
        public NewspaperProperties.ReadabilityLevel readabilityLevel { get { return _readabilityLevel; } set { _readabilityLevel = value; } }

        public Page(Content content, NewspaperProperties newspaperProperties)
        {
            NoOfCols = newspaperProperties.NoOfCols;
            NoOfRows = newspaperProperties.NoOfRows;
            WidthOfPage = newspaperProperties.WidthOfPage;
            ColumnSpacing = newspaperProperties.ColumnSpacing;
            this.readabilityLevel = readabilityLevel;
            WidthOfRow = (WidthOfPage - (NoOfCols - 1) * 3) / NoOfCols;
            Columns = new List<Column>();
            for (int i = 0; i < NoOfCols; i++)
            {
                Column column = new Column(content, newspaperProperties);
                Columns.Add(column);
            }
        }
        // public void printPage(IFileWriter fileWriter)
        // {
        //     fileWriter.writeLine("");
        //     for (int i = 0; i < NoOfRows; i++)
        //     {
        //         fileWriter.write("   ");
        //         for (int j = 0; j < NoOfCols; j++)
        //         {
        //             fileWriter.write(Columns[j].Rows[i] + "   ");
        //         }
        //         fileWriter.writeLine("");
        //     }
        //     String pageBreak = "";
        //     pageBreak = pageBreak.PadRight(WidthOfPage, '-');
        //     fileWriter.writeLine("\n" + pageBreak);
        // }
    }
}