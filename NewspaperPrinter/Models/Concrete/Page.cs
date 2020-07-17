using System;
using System.Collections.Generic;
using NewspaperPrinter.Models.Interfaces;

namespace NewspaperPrinter.Models.Concrete
{
    public class Page
    {
        public List<Column> Columns { get; set; }
        public int NoOfCols { get; set; }
        public int NoOfRows { get; set; }
        public int WidthOfPage { get; set; }
        public int WidthOfRow { get; set; }
        public int ColumnSpacing { get; set; }
        public NewspaperProperties.ReadabilityLevel readabilityLevel { get; set; }

        public void printPage(IStreamWriter streamWriter)
        {
            string columnSpacer = "";
            columnSpacer = columnSpacer.PadRight(ColumnSpacing, ' ');
            streamWriter.writeLine("");
            for (int i = 0; i < NoOfRows; i++)
            {
                streamWriter.write(columnSpacer);
                for (int j = 0; j < NoOfCols; j++)
                {
                    streamWriter.write(Columns[j].Rows[i] + columnSpacer);
                }
                streamWriter.writeLine(String.Empty);
            }
            String pageBreak = "";
            pageBreak = pageBreak.PadRight(WidthOfPage, '-');
            streamWriter.writeLine("\n" + pageBreak);
        }
    }
}