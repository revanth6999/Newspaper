using NewspaperFormatter.Models.Concrete;
using NewspaperFormatter.Models.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace NewspaperFormatter.Models.Services
{
    class NewspaperMachine
    {
        private Content content;
        private int choice;
        private NewspaperProperties newspaperProperties;
        private List<INewspaperFactory> factories = new List<INewspaperFactory>();
        public NewspaperMachine(int choice, Content content, NewspaperProperties newspaperProperties)
        {
            this.choice = choice;
            this.content = content;
            this.newspaperProperties = newspaperProperties;
            this.factories = NewspaperFactoriesScanner.factories;
            if (choice < 1 || choice > factories.Count)
            {
                throw new InvalidDataException("Invalid choice value");
            }
        }
        public Newspaper getNewspaper()
        {
            if (choice < 1 || choice > factories.Count)
            {
                throw new InvalidDataException("Invalid choice value");
            }
            return factories[choice - 1].makeNewspaper(content, newspaperProperties);
        }
    }
}