using System;
using System.IO;

namespace CeaserCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Ceaser Cipher ###");

            UserInterface UI = new UserInterface();

            UI.MainMenu();
        }
    }
}
