using System;

namespace HighLow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create Random object
            Random random = new Random();

            // random int from range, max is excusive
            int secret = random.Next(1, 11);
            bool isActive = true;
            bool isValid;
            int guess;
            int remainingGuesses = 3;

            do
            {
                Console.WriteLine("Guess a number between 1 and 10");
                isValid = int.TryParse(Console.ReadLine(), out guess);
                
                if (isValid)
                {
                    remainingGuesses--;

                    if (guess == secret)
                    {
                        Console.WriteLine("You guessed the number!");
                        isActive = false;
                    }
                    else
                    {
                        if (remainingGuesses == 0)
                        {
                            Console.WriteLine("Sorry, you are out of guesses. The number was " + secret);
                            isActive = false;
                        }
                        else if (guess < secret)
                        {
                            Console.WriteLine($"Sorry, you guessed too low. You have {remainingGuesses} guesses remaining.");
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, you guess too high. You have {remainingGuesses} guesses remaining.");
                        }
                    }
                } 
                else
                {
                    Console.WriteLine("Not a valid guess. Try again.");
                }

                if (!isActive)
                {
                    Console.WriteLine("Play Again? (Y)");
                    string response = Console.ReadLine();

                    if (response.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        secret = random.Next(1, 11);
                        guess = 0;
                        remainingGuesses = 3;
                        isActive = true;
                    }
                }
            } while (isActive);

        }
    }
}
