using System;
using System.Collections.Generic;
using System.Text;

namespace CaeserCipher
{
    public class Attempt
    {
        // Properties
        public int keyGuess { get; set; }

        public string rawGuess { get; set; }

        public string[] decodedWords { get; set; }

        public int numberOfRealWords { get; set; }
    }
}
