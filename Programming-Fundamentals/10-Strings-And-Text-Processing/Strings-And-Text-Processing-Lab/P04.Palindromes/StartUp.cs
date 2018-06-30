using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Palindromes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new char[] {' ', '.', ',', '?', '!', '-'},
                StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> words=new HashSet<string>();

            foreach (var word in text)
            {
                if (isPalindrome(word))
                {
                    words.Add(word);
                }
            }

            var sortedPalindromes = words.OrderBy(a => a).ToArray();
            Console.WriteLine(string.Join(", ",sortedPalindromes));
        }

        private static bool isPalindrome(string word)
        {
            for (int i = 0; i < word.Length/2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
