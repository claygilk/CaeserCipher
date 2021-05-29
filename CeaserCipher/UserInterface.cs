using System;
using System.Collections.Generic;
using System.Text;

namespace CeaserCipher
{
    public class UserInterface
    {
        public void MainMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Choose an Option: ");
                Console.WriteLine("1: Encode Message with Ceaser Cipher");
                Console.WriteLine("2: Decode Message with Ceaser Cipher");
                Console.WriteLine("3:  Crack Message with Ceaser Cipher");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Encoder");
                        this.EncoderMenu();
                        break;
                    case "2":
                        Console.WriteLine("Decoder");
                        this.DecoderMenu();
                        break;
                    case "3":
                        Console.WriteLine("Crack");
                        this.CrackMenu();
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Choice");
                        break;
                }
            }
        }

        public void CrackMenu()
        {
            bool keepRunning = true;
            Ceaser ceaser = new Ceaser();

            while (keepRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Input Ciphertext: ");
                string cipher = Console.ReadLine();

                if (cipher == "q")
                {
                    keepRunning = false;
                    break;
                }

                ceaser.Crack(cipher);
            }
        }
        public void DecoderMenu()
        {
            bool keepRunning = true;
            Ceaser ceaser = new Ceaser();

            while (keepRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Input Ciphertext: ");
                string cipher = Console.ReadLine();

                if (cipher == "q")
                {
                    keepRunning = false;
                    break;
                }

                bool IsKeyInvalid = true;
                int key;
                do
                {
                    Console.WriteLine("Input Key: ");
                    key = Convert.ToInt32(Console.ReadLine());

                    if (key < 1 || key > 26)
                    {
                        Console.WriteLine("Please enter a valid key (1-26)");
                    }
                    else
                    {
                        IsKeyInvalid = false;
                    }
                }
                while (IsKeyInvalid);

                Console.Write("Plain Text: ");
                Console.Write(ceaser.DecodeCipher(cipher, key));
            }
        }

        public void EncoderMenu()
        {
            bool keepRunning = true;
            Ceaser ceaser = new Ceaser();

            while (keepRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Input Plaintext: ");
                string message = Console.ReadLine();

                if (message == "q")
                {
                    keepRunning = false;
                    break;
                }

                bool IsKeyInvalid = true;
                int key = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Input Key: ");
                        key = Convert.ToInt32(Console.ReadLine());

                        if (key < 1 || key > 26)
                        {
                            Console.WriteLine("Please enter a valid key (1-26)");
                        }
                        else
                        {
                            IsKeyInvalid = false;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                while (IsKeyInvalid);


                ceaser.EncodeMessage(message, key);

            }
        }
    }
}
