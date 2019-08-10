using System;
using System.Collections.Generic;

namespace WordTransfer_from_Dictionary
{
    class Program
    {
        private HashSet<string> result = new HashSet<string>();

        private bool GetNearestWord(string word, string dictWord)       //get the most adjacent word from the dictionary which has only differs by one character
        {
            int count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != dictWord[i])
                {
                    count++;
                    if (count > 1)
                        break;
                }
            }

            if (count == 1)
                return true;
            else
                return false;
        }

        private void WordTransfer(string start, string target)
        {
            if (start.Length == target.Length)
            {
                string tempStr = start;

                HashSet<string> dictionary = new HashSet<string>() { "POON", "PLEE", "SAME", "POIE", "PLEA", "PLIE", "POIN",
                                                                "LAMP", "LIMP", "LIME", "LIKE" };

                while (tempStr != target)       //run the loop until we reach the target word
                {
                    foreach (var word in dictionary)
                    {
                        if (GetNearestWord(tempStr.ToUpper(), word))
                        {
                            tempStr = word;
                            result.Add(word);
                            Console.Write(word + " ->");
                        }

                    }
                    foreach (var item in result)
                    {
                        dictionary.Remove(item);        //remove already used dictionary words to avoid infinite looping 
                    }
                }
            }
            else
            {
                Console.WriteLine("Please Enter Valid words of same length");
            }
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
 
            Console.WriteLine("Enter a word from dictionary");
            string start = Console.ReadLine();

            Console.WriteLine("Enter the target word from dictionary");
            string target = Console.ReadLine();

            obj.WordTransfer(start, target);
            Console.ReadKey();
        }
    }
}
