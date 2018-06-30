using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string>();

            using (var wordsReader = new StreamReader("../words.txt"))
            {
                string line = wordsReader.ReadLine();
                while (line != null)
                {
                    words.Add(line.Trim());

                    line = wordsReader.ReadLine();
                }
            }
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            using (var textReader = new StreamReader("../text.txt"))
            {
                string line = textReader.ReadLine();
                while (line != null)
                {
                    var lineArr = Regex.Split(line, @"\W+",RegexOptions.IgnorePatternWhitespace);
                    lineArr = lineArr.Select(a => a.ToLower()).ToArray();
                    
                    foreach (var wordInText in lineArr)
                    {
                        foreach (string searchedWord in words)
                        {
                            if (wordInText == searchedWord)
                            {
                                if (!dictionary.ContainsKey(searchedWord))
                                {
                                    dictionary[searchedWord] = 0;
                                }
                                dictionary[searchedWord]++;
                            }
                        }
                    }
                    line = textReader.ReadLine();
                }
            }
            using (var streamWriter = new StreamWriter("Result.txt"))
            {
                foreach (KeyValuePair<string, int> pair in dictionary.OrderByDescending(a => a.Value))
                {
                    streamWriter.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
            
        }
    }
}
