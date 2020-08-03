using NewspaperFormatter.Models.Interfaces;
using System;
using System.Collections.Generic;
namespace NewspaperFormatter.Models.Concrete
{
    public class Newspaper
    {
        private List<Page> _pages;
        private int _noOfCols;
        private int _noOfRows;
        private int _widthOfPage;
        private int _noOfPages;
        private NewspaperProperties.ReadabilityLevel _readabilityLevel;
        public List<Page> Pages { get { return _pages; } set { _pages = value; } }
        public int NoOfCols { get { return _noOfCols; } set { _noOfCols = value; } }
        public int NoOfRows { get { return _noOfRows; } set { _noOfRows = value; } }
        public int WidthOfPage { get { return _widthOfPage; } set { _widthOfPage = value; } }
        public int NoOfPages { get { return _noOfPages; } set { _noOfPages = value; } }
        public NewspaperProperties.ReadabilityLevel readabilityLevel { get { return _readabilityLevel; } set { _readabilityLevel = value; } }
        public Newspaper(Content content, NewspaperProperties newspaperProperties, IFormatter formatter)
        {
            try
            {
                NoOfCols = newspaperProperties.NoOfCols;
                NoOfRows = newspaperProperties.NoOfRows;
                WidthOfPage = newspaperProperties.WidthOfPage;
                Pages = new List<Page>();
                this.readabilityLevel = readabilityLevel;
                while (!content.isEmpty())
                {
                    NoOfPages++;
                    Page page = new Page(content, newspaperProperties, formatter);
                    Pages.Add(page);
                }
            }
            catch (Exception)
            {
                throw new Exception("Newspaper with the given dimensions cannot be created.");
            }
        }
    }
}