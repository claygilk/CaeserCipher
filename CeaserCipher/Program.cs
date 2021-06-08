using System;
using System.IO;

namespace CaeserCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Caeser Cipher ###");

            UserInterface UI = new UserInterface();

            UI.MainMenu();
        }
    }
}
