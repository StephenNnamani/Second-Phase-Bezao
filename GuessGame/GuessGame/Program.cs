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

            //Logic of whether a play won or lost
            string winORlose = "You Lost";

            //-------------------------------------------------------

            Console.WriteLine("=============================================================================================");
            Console.WriteLine(@"Welcome to STEPHEN'S GUESS GAME
Here you have 5 attempts to get the correct secret random number. 
Each attempt tells you if you are higher or lower than the secret number. and the secret number changes after each game.");
            Console.WriteLine("============================================================================================= \n \nFirst, tell us about yourself \n");

            Users newUser = new Users();

            Console.Write("Type in your First name: ");
            var firstName = newUser.firstName;
            firstName = Console.ReadLine();

            Console.Write("Type in your Last name: ");
            var lastName = newUser.lastName;
            lastName = Console.ReadLine();

            Console.Write("Type in your age: ");
            var age = newUser.age;
            age = Convert.ToInt64(Console.ReadLine());
         
            Console.Write("Type in your height: ");
            var height = newUser.height;
            height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Type in your Skin Color: ");
            var complexion = newUser.complexion;
            complexion = Console.ReadLine();

            Console.Write("Type in your State: ");
            var state = newUser.state;
            state = Console.ReadLine();

            Console.Write("Type in your Country: ");
            var Country = newUser.Country;
            Country = Console.ReadLine();
            Console.WriteLine($"\n\n\nNow let's play the game, {firstName}");

            var played = 0;
            var won = 0;
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

                    if(SecretNumber != guess){
                        Console.WriteLine($"You have {limitedGuess} number of tries remaining");
                    }
                    if (limitedGuess == 1 && SecretNumber != guess)
                    {
                        Console.WriteLine("This is your last try");
                    }
                    played++;
                    if (SecretNumber == guess)
                    {
                        var count = guessedNumbers.Count();
                        Console.WriteLine("YOU WIN!");
                        Console.WriteLine("The Secret Number is: " + SecretNumber);
                        Console.WriteLine("Number of Tries: " + count);
                        winORlose = "You WON!!!";
                        won++;
                    }

                }
                

                do{
                        Console.WriteLine("Would you like to play again (Y/N): ");
                        response = Console.ReadLine();
                        response = response.ToUpper();
                        if (response == "Y")
                        {
                             playAgain = true;
                            break;
                        }
                        else if (response == "N")
                        {
                             playAgain = false;
                            break;
                        } else{
                            Console.WriteLine("Please type in the correct Character Y or N");
                        }
                }while(response != "Y" || response != "N");
            }
                Console.WriteLine("Thanks for playing! ... I guess");


             Console.WriteLine($@"
Name:                   {firstName} {lastName}
Age:                    {age}
State:                  {state}
Country:                {Country}
complexion:             {complexion}
Height:                 {height}cm

Game:                   {winORlose} the game
Games Played:           {played}
Number of Guesses won:  {won};
Number of Guesses lost: {played - won};
Thank You");

            //currency();
           
            Console.ReadKey();
            
            }
        private static void currency(){
            Console.WriteLine("{0:C}", 123.34, "\n");
            Console.WriteLine("\n==============================================================================\n");
            DateTime myBirthday = DateTime.Parse("02/11/1991");
            TimeSpan daysOnEarth = DateTime.Now.Subtract(myBirthday);


            Console.WriteLine("\n==============================================================================\n");

            DateTime today = DateTime.Today;
            Console.WriteLine(today.ToLongDateString());

            Console.WriteLine(daysOnEarth);


        }
    }
    class Users
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long age { get; set; }
        public string complexion { get; set; }
        public Double height { get; set; }
        public string Country { get; set; }
        public string state { get; set; }
    }
}