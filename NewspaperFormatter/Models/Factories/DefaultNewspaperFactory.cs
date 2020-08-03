using NewspaperFormatter.Models.Concrete;
using NewspaperFormatter.Models.Interfaces;
using NewspaperFormatter.Models.Services;

namespace NewspaperFormatter.Models.Factories
{
    class DefaultNewspaperFactory : INewspaperFactory
    {
        public Newspaper makeNewspaper(Content content, NewspaperProperties newspaperProperties)
        {
            return new Newspaper(content, newspaperProperties, new RowsFormatter());
        }
    }
}