using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            string Comments;
            bool translateAgain = true;

            Console.WriteLine("=============================================================================================");
            Console.WriteLine(@"Welcome to the English to Pig Latin Translation CLI");
            Console.WriteLine("=============================================================================================");

            while (translateAgain)
            {
                string ay = "ay";
                

                Console.WriteLine("English to Pig Latin = Press 1 \nPig Latin to English = Press 2");
                string T = Console.ReadLine();

                if (T == "1")
                {
                    Console.WriteLine("Type in the English words you wish to translate back to Pig Latin: ");
                    Comments = Console.ReadLine();
                    foreach (string letters in Comments.Split(' '))
                    {
                        string firstLetter = letters.Substring(0, 1);
                    
                        string restOfWord = letters.Substring(1, letters.Length - 1);

                        string Converted = restOfWord+firstLetter+ay + " ";

                        var lowerCase = Converted.ToLower();
                    

                        var patterns = @"(^[a-z,.;?])|\.\s+";
                        var r = new Regex(patterns, RegexOptions.ExplicitCapture);

                        // Creates a TextInfo based on the "en-US" culture.
                        TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
                        var result = r.Replace(lowerCase, s => s.Value.ToUpper());
                        Console.Write(myTI.ToTitleCase(result));
                    }
                
                }
                else if(T == "2")
                {
                    string latinCapture;
                    Console.WriteLine("Type in the latin words you wish to translate back to English: ");
                    latinCapture = Console.ReadLine();
                    foreach (string letters in latinCapture.Split(' '))
                    {
                        //Capturing the last three letters of each word
                        string lastThree = letters.Substring(letters.Length-3);
                       // Console.WriteLine(lastThree);
                        string firstLetter;

                        foreach(char letter in lastThree.IndexOf(0))
                        {
                            firstLetter = Char.ToString(letter);
                            Console.WriteLine(firstLetter);
                        } 

                        string restOfWord = letters.Substring(0, letters.Length - 3);

                      // string Converted = firstLetter+restOfWord + " ";

                       //Console.WriteLine(Converted);
                    }
                }
                else
                {
                    Console.WriteLine("Please select the RIGHT option i.e either 1 or 2");
                }
            }
                

                Console.WriteLine("\n =============================================================================================");
                Console.WriteLine("Do you want to translate again?(Y/N): ");
                var newPlay = Console.ReadLine();

                if (newPlay == "N" || newPlay == "n")
                {
                    translateAgain = false;
                    Console.WriteLine("Thank You for translating");

                }else if (newPlay == "Y" || newPlay == "y")
                {
                    translateAgain = true;
                }
            
                Console.WriteLine("Press any key to terminate");
                Console.ReadKey();
        }
    }
}
