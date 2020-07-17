using NewspaperFormatter.Models.Concrete;

namespace NewspaperFormatter.Models.Interfaces
{
    public interface INewspaperFactory
    {
        Newspaper makeNewspaper(Content content, NewspaperProperties newspaperProperties);
    }
}
