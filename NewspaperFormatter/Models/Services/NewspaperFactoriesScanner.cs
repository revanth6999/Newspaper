using NewspaperFormatter.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace NewspaperFormatter.Models.Services
{
    public class NewspaperFactoriesScanner
    {
        protected static List<INewspaperFactory> _factories = new List<INewspaperFactory>();
        protected static List<String> _factoryNames = new List<String>();
        public static List<INewspaperFactory> factories { get { return _factories; } }
        public static List<String> factoryNames { get { return _factoryNames; } }

        public NewspaperFactoriesScanner()
        {
            foreach (Type type in typeof(NewspaperFactoriesScanner).Assembly.GetTypes())
            {
                if (typeof(INewspaperFactory).IsAssignableFrom(type) && !type.IsInterface)
                {
                    _factories.Add((INewspaperFactory)Activator.CreateInstance(type));
                    _factoryNames.Add(type.Name.Replace("NewspaperFactory", " Newspaper"));
                }
            }
        }
    }
}
