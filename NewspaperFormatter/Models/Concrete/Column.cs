using NewspaperFormatter.Models.Services;
using System;
using System.Collections.Generic;
namespace NewspaperFormatter.Models.Concrete
{
    public class Column
    {
        private List<String> _rows;
        private int _noOfRows;
        private int _widthOfRow;
        public List<String> Rows { get { return _rows; } set { _rows = value; } }
        public int NoOfRows { get { return _noOfRows; } set { _noOfRows = value; } }
        public int WidthOfRow { get { return _widthOfRow; } set { _widthOfRow = value; } }
        public Column(Content content, NewspaperProperties newspaperProperties)
        {
            NoOfRows = newspaperProperties.NoOfRows;
            WidthOfRow = newspaperProperties.WidthOfRow;
            RowsFormatter rowFormatter = new RowsFormatter();
            Rows = rowFormatter.format(content, newspaperProperties);
        }
    }
}