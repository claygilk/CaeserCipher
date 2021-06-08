using System;
using System.Collections.Generic;
using System.Text;

namespace CaeserCipher
{
    interface ICipher
    {
        public string EncodeMessage(string input, int key);

        public string DecodeCipher(string input, int key);

        public string Crack(string input);
    }
}
