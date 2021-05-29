using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CeaserCipher
{
    public class Corpus
    {
        public List<string> EnglishWords { get; set; }

        public bool CheckWord(string input)
        {
            string dataFilePath = "C:\\Users\\Student\\source\\repos\\CeaserCipher\\CeaserCipher\\en_US-large.txt";
            StreamReader dictionaryFile = new StreamReader(dataFilePath);

            this.EnglishWords = new List<string>();

            while (!dictionaryFile.EndOfStream)
            {
                this.EnglishWords.Add(dictionaryFile.ReadLine().ToUpper());
            }

            if (this.EnglishWords.Contains(input))
            {
                return true;
                Console.WriteLine("is a real word");
            }
            else
            {
                return false;
                Console.WriteLine("not a real word");
            }


        }

    }
}
