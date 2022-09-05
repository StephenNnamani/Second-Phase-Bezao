using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
           Random random = new Random();

            bool playAgain = true;  // Checkes if you want to play again

            // The range of numbers to pick from or generated randomly
            int min = 1;
            int max = 100;

            //-------------------------------------------------------
            // List of guess variables
            int guess;                                 //The number guessed by the player
            int numberOfGuesses = 0;                  //How many times a player has guessed
            
            List<int> guessedNumbers = new List<int>();      //list of saved guessed numbers

            //-------------------------------------------------------
            //Response to want to play again

            String response;

            //-------------------------------------------------------
            //Secret Number

            int SecretNumber;

            //-------------------------------------------------------

            Console.WriteLine("=============================================================================================");
            Console.WriteLine(@"Welcome to STEPHEN'S GUESS GAME
Here you have 5 attempts to get the correct secret random number. 
Each attempt tells you if you are higher or lower than the secret number. and the secret number changes after each game");
            Console.WriteLine("============================================================================================= \n");


            while (playAgain)
            {
                int limitedGuess = 5;                    //The number of times to remaining to play
                guess = 0;
                response = "";
                SecretNumber = random.Next(min, max + 1);
                guessedNumbers.Clear();
                
                while (guess != SecretNumber && limitedGuess > 0)
                {
                    Console.WriteLine("Guess a number between " + min + " - " + max + " : ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Guess: " + guess);

                    while (guessedNumbers.Contains(guess))
                    { 
                        Console.WriteLine($"You are repeating your previous guess {guess}");
                        Console.WriteLine("Guess a number between " + min + " - " + max + " : ");
                        guess = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Guess: " + guess);
                    }
                    guessedNumbers.Add(guess);
                    numberOfGuesses++;

                    limitedGuess -= 1;
                    if (guess > SecretNumber)
                    {
                        Console.WriteLine(guess + " is to high!");
                    }
                    else if (guess < SecretNumber)
                    {
                        Console.WriteLine(guess + " is to low!");
                    }

                    Console.WriteLine($"You have {limitedGuess} number of tries remaining");
                    if (limitedGuess == 1)
                    {
                        Console.WriteLine("This is your last try");
                    }
                    if (SecretNumber == guess)
                    {
                        var count = guessedNumbers.Count();
                        Console.WriteLine("The Secret Number is: " + SecretNumber);
                        Console.WriteLine("YOU WIN!");
                        Console.WriteLine("Number of Tries: " + count);
                    }
                }
                


                Console.WriteLine("Would you like to play again (Y/N): ");
                response = Console.ReadLine();
                response = response.ToUpper();

                if (response == "Y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            }
                Console.WriteLine("Thanks for playing! ... I guess");

                Console.ReadKey();
            
            }

        }
    }