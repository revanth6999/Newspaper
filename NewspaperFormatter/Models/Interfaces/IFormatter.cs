using NewspaperFormatter.Models.Concrete;
using System;
using System.Collections.Generic;

namespace NewspaperFormatter.Models.Interfaces
{
    public interface IFormatter
    {
        public List<String> format(Content content, NewspaperProperties newspaperProperties);
    }
}
