using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CaeserCipher

{
    public class Caeser : ICipher
    {

        // Properties
        public Dictionary<string, int> Alphabet { get; }
        public Dictionary<int, string> LookupAlphabet { get; }

        // Constructor
        public Caeser()
        {
            this.Alphabet = new Dictionary<string, int>()
            {
                {"A",0 }, {"B",1 },{"C",2 }, {"D",3 }, {"E",4 },{"F",5 }, {"G",6 }, {"H",7 }, {"I",8 }, {"J",9 },{"K",10 },{"L",11}, {"M",12}, {"N",13}, {"O",14 },  {"P",15 }, {"Q",16 }, {"R",17 }, {"S",18 }, {"T",19 }, {"U",20 }, {"V",21 }, {"W",22 }, {"X",23 }, {"Y",24 }, {"Z",25 },
            };

            this.LookupAlphabet = new Dictionary<int, string>()
            {
                {0, "A"}, {1 ,"B"},{2,"C"}, {3,"D"}, {4,"E"},{5,"F"}, {6,"G"}, {7,"H"}, {8,"I"}, {9,"J"},{10,"K" },{11,"L"}, {12,"M"}, {13,"N"}, {14,"O"},  {15,"P"}, {16,"Q"}, {17,"R"}, {18,"S" }, {19,"T"}, {20,"U"}, {21,"V"}, {22,"W"}, {23,"X"}, {24,"Y"}, {25,"Z"},
            };
        }

        // Methods
        private string DecodeCharacter(string character, int key)
        {
            int startValue = Alphabet[character];
            int endValue = startValue - key;

            if (endValue < 0)
            {
                endValue += 26;
            }

            return this.LookupAlphabet[endValue];
        }

        public string EncodeCharacter(string character, int key)
        {
            int startValue = Alphabet[character];
            int endValue = startValue + key;

            if (endValue > 25)
            {
                endValue -= 26;
            }

            return this.LookupAlphabet[endValue];
        }

        public List<string> GetListOfChars(string text)
        {
            List<string> listOfChars = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                string character = text.Substring(i, 1);
                listOfChars.Add(character.ToUpper());
            }

            return listOfChars;
        }

        public string EncodeMessage(string plainText, int key)
        {
            foreach (string character in GetListOfChars(plainText))
            {
                if (this.Alphabet.ContainsKey(character))
                {
                    Console.Write(EncodeCharacter(character, key));
                }
                else
                {
                    Console.Write(character);
                }
            }

            return "";
        }

        public string Crack(string input)
        {
            List<Attempt> guesses = new List<Attempt>();

            Corpus dictionaryFile = new Corpus();

            for (int i = 1; i < 26; i++)
            {
                Attempt crack = new Attempt();
                input = RemovePunctuation(input);

                crack.keyGuess = i;
                crack.rawGuess = DecodeCipher(input, i);
                crack.decodedWords = crack.rawGuess.Split(" ");
                crack.numberOfRealWords = ScoreGuess(crack, dictionaryFile);

                guesses.Add(crack);
            }

            int bestGuess = 0;
            Attempt winner = new Attempt();

            foreach (Attempt guess in guesses)
            {
                if (guess.numberOfRealWords > bestGuess)
                {
                    bestGuess = guess.numberOfRealWords;
                    winner = guess;
                }


            }

            Console.WriteLine("Key (guess): " + winner.keyGuess);
            Console.WriteLine("PlainText (guess):" + winner.rawGuess);

            return "";
        }


        private static int ScoreGuess(Attempt crack, Corpus dictionaryFile)
        {
            int wordCounter = 0;
            foreach (string word in crack.decodedWords)
            {
                if (dictionaryFile.CheckWord(word))
                {
                    wordCounter++;
                }
            }

            return wordCounter;
        }

        public static string RemovePunctuation(string text)
        {
            text = text.Replace(".", "");
            text = text.Replace(",", "");
            text = text.Replace("?", "");
            text = text.Replace("!", "");
            text = text.Replace(":", "");
            text = text.Replace(";", "");
            text = text.Replace("\"", "");
            text = text.Replace("\'", "");
            return text;
        }

        public string DecodeCipher(string cipherText, int key)
        {
            string decodedCipher = "";

            foreach (string character in GetListOfChars(cipherText))
            {
                if (this.Alphabet.ContainsKey(character))
                {
                    decodedCipher += DecodeCharacter(character, key);
                }
                else
                {
                    decodedCipher += character;
                }
            }

            return decodedCipher;
        }


    }
}
