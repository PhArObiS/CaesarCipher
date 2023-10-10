using System;

namespace CaesarCipherJan19
{
    internal class Caesar
    {
        internal static byte Option;
        internal static bool Restart = false;

        // Title Page
        internal static void DisplayTitle(string message, int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ResetColor();
            }
        }

        // Function for choosing options for encryption or decryption
        internal static void ChooseOption()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Who's winning the Super Bowl?");
            Console.WriteLine("******************************");
            string superBowl = Console.ReadLine();


            Console.WriteLine($"Ok, thank you. You have chosen the {superBowl} as your Super Bowl 2023 pick! ");
            Console.WriteLine("Do you want to Encrypt or Decrypt your pick? \nChoose from the menu: \n1. Encrypt \n2. Decrypt\n ");

            string? userInput = Console.ReadLine();

            // Error handling for invalid inputs
            if (!byte.TryParse(userInput, out byte userOption) || userOption < 1 || userOption > 2)
            {
                Console.WriteLine($"You have chosen an invalid option! ({userInput})");
                return;
            }

            Console.WriteLine($"You have chosen option #{userOption}!");
            Option = userOption;

            Console.WriteLine($"Enter a shift value! (1 min. à 26 max.)");
            string? shiftInput = Console.ReadLine();

            // Error handling for invalid shift inputs
            if (!byte.TryParse(shiftInput, out byte shift) || shift < 1 || shift > 26)
            {
                Console.WriteLine($"The entered shift is invalid!");
                return;
            }

            int x = shift;
            superBowl = superBowl.ToLower();
            char[] secretMessage = superBowl.ToCharArray();
            switch (Option)
            {
                case 1:
                    string secret = Encrypt(secretMessage, x); // Avoiding duplicate call
                    Console.WriteLine(secret);
                    break;
                case 2:
                    string secrt = Decrypt(secretMessage, x);
                    Console.WriteLine(secrt);
                    break;
            }
        }

        // Function to encrypt
        static string Encrypt(char[] secretMessage, int key)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                var letter = secretMessage[i];
                int index = Array.IndexOf(alphabet, letter);
                int newIndex = (key + index) % 26;
                char newLetter = alphabet[newIndex];
                encryptedMessage[i] = newLetter;
            }

            return new string(encryptedMessage);
        }

        // Function to decrypt
        static string Decrypt(char[] secretMessage, int key)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            char[] decryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                var letter = secretMessage[i];
                int index = Array.IndexOf(alphabet, letter);
                int newIndex = (index - key + 26) % 26; // Handles negative values
                char newLetter = alphabet[newIndex];
                decryptedMessage[i] = newLetter;
            }

            return new string(decryptedMessage);
        }

        // Restart function
        internal static void ThankYou()
        {
            Console.WriteLine("We hope you enjoyed the experience. Press (R) to restart.");
            string? userInput = Console.ReadLine();
            Restart = userInput != null && userInput.ToLower()[0] == 'r';
        }

    }
}