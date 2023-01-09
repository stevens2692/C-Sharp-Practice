using System;

namespace C_sharp_practice
{
    class GuessWord
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the GuessWord game.\nGuess the password in 5 tries or less\nFor every failed guess you will receive another letter of the password.");
            string password = "Giraffe";
            string guess = "";
            int guessCount = 0;
            string clue = "";
            bool correctPassword = false;
            while (guessCount < 5)
            {
                Console.WriteLine("What is your guess: ");
                guess = Console.ReadLine();
                if (guess.Equals(password))
                {
                    correctPassword = true;
                    break;
                }
                clue = clue + password[guessCount];
                Console.WriteLine("Password clue: " + clue);
                guessCount++;
            }
            if (correctPassword)
            {
                Console.WriteLine("Well done, you guessed the correct password!");
            }
            else
            {
                Console.WriteLine("You ran out of guesses!");
            }
        }
    }
}
