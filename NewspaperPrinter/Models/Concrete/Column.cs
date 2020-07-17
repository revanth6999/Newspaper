using System;
using System.Collections.Generic;
namespace NewspaperPrinter.Models.Concrete
{
    public class Column
    {
        public List<String> Rows { get; set; }
        public int NoOfRows { get; set; }
        public int WidthOfRow { get; set; }
    }
}