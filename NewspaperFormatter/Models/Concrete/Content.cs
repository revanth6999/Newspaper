using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NewspaperFormatter.Models.Concrete
{
    public class Content
    {
        private List<String> words;

        public List<String> getWords()
        {
            return this.words;
        }

        public Content(String text)
        {
            text = Regex.Replace(text, @"\s+", " ");
            words = text.Split(' ').ToList();
        }

        public bool isEmpty()
        {
            return words.Count == 0;
        }
    }
}