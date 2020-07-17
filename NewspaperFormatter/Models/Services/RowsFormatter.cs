using NewspaperFormatter.Models.Concrete;
using System;
using System.Collections.Generic;
namespace NewspaperFormatter.Models.Services
{
    class RowsFormatter
    {
        public List<String> format(Content content, NewspaperProperties newspaperProperties)
        {
            int NoOfRows = newspaperProperties.NoOfRows;
            int WidthOfRow = newspaperProperties.WidthOfRow;
            NewspaperProperties.ReadabilityLevel readabilityLevel = newspaperProperties.readabilityLevel;
            List<String> rows = new List<String>();
            List<String> words = content.getWords();
            int level = (int)readabilityLevel + 1;
            for (int i = 0; i < NoOfRows; i++)
            {
                String text = "";
                int wordCount = 0;
                while (!content.isEmpty() && (words[0].Length + text.Length + 1) <= WidthOfRow)
                {
                    if (wordCount > 0)
                        text = text + " " + words[0];
                    else
                        text = words[0];
                    words.RemoveAt(0);
                    wordCount++;
                }
                if (!content.isEmpty())
                {
                    String word = "";
                    String remainingWord = "";
                    int remainingSpace = 0;
                    switch (wordCount)
                    {
                        case 0:
                            word = words[0].Substring(0, WidthOfRow - 1) + "-";
                            text = word;
                            remainingWord = words[0].Substring(WidthOfRow - 1);
                            words.RemoveAt(0);
                            words.Insert(0, remainingWord);
                            break;
                        case 1:
                            remainingSpace = WidthOfRow - text.Length - 1;
                            if (remainingSpace > 1)
                            {
                                word = words[0].Substring(0, remainingSpace - 1) + "-";
                                remainingWord = words[0].Substring(remainingSpace - 1);
                                text = text + " " + word;
                                words.RemoveAt(0);
                                words.Insert(0, remainingWord);
                            }
                            else
                            {
                                text = text.PadRight(WidthOfRow, ' ');
                            }
                            break;
                        default:
                            if (text.Length < WidthOfRow)
                            {
                                remainingSpace = WidthOfRow - text.Length;
                                if (remainingSpace < (WidthOfRow / level))
                                {
                                    String commonSpaces = "";
                                    commonSpaces = commonSpaces.PadLeft(remainingSpace / (wordCount - 1), ' ');
                                    int remainderSpaces = remainingSpace % (wordCount - 1);
                                    int spaceSearchStartIndex = 0;
                                    for (int k = 0; k < wordCount - 1; k++)
                                    {
                                        int position = text.IndexOf(' ', spaceSearchStartIndex);
                                        if (remainderSpaces > 0)
                                        {
                                            text = text.Substring(0, position + 1) + commonSpaces + " " + text.Substring(position + 1);
                                            remainderSpaces--;
                                            spaceSearchStartIndex = position + commonSpaces.Length + 2;
                                        }
                                        else
                                        {
                                            text = text.Substring(0, position + 1) + commonSpaces + text.Substring(position + 1);
                                            spaceSearchStartIndex = position + commonSpaces.Length + 1;
                                        }
                                    }
                                }
                                else
                                {
                                    if (remainingSpace > 1)
                                    {
                                        word = words[0].Substring(0, remainingSpace - 2) + "-";
                                        remainingWord = words[0].Substring(remainingSpace - 2);
                                        text = text + " " + word;
                                        words.RemoveAt(0);
                                        words.Insert(0, remainingWord);
                                    }
                                    else
                                    {
                                        text = text.PadRight(WidthOfRow, ' ');
                                    }
                                }

                            }
                            break;
                    }
                }
                rows.Add(text);
            }
            return rows;
        }
    }
}