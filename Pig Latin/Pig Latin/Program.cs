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
                    foreach (string words in Comments.Split(' '))
                    {
                        string firstLetter = words.Substring(0, 1);
                    
                        string restOfWord = words.Substring(1, words.Length - 1);

                        string Converted = restOfWord+firstLetter+ay + " ";

                        var lowerCase = Converted.ToLower();
                    

                        var patterns = @"(^[a-z,.;?])|\.\s+";
                        var r = new Regex(patterns, RegexOptions.ExplicitCapture);

                        // Creates a TextInfo based on the "en-US" culture.
                        TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
                        var result = r.Replace(lowerCase, s => s.Value.ToUpper());
                        Console.Write(myTI.ToTitleCase(result) + " ");
                    }
                
                }
                else if(T == "2")
                {
                    string latinCapture;
                    Console.WriteLine("Type in the latin words you wish to translate back to English: ");
                    latinCapture = Console.ReadLine();

                    string lastThree;
                    
                    foreach (string letters in latinCapture.Split(' '))
                    {
                        //Capturing the last three letters of each word
                        lastThree = letters.Substring(letters.Length - 3);
                        //extracting the first letter of the lastThree
                        var firstLetter = lastThree.Remove(1, 2);
                        //The rest of the words without the last three
                        string restOfWord = letters.Substring(0, letters.Length - 3);
                        // Concatenation of all the words
                        string Converted = firstLetter+restOfWord + " ";

                        Console.Write(Converted);
                    }
                }
                else
                {
                    Console.WriteLine("Please select the RIGHT option i.e either 1 or 2");
                }
                Console.WriteLine("\n\n");
                Console.Write("Do you want to Translate anything else? Y or N:   ");
                var res = Console.ReadLine(); res = res.ToLower();
                if (res == "n")
                {
                    break;
                }
            }
                

               /* Console.WriteLine("\n =============================================================================================");
                Console.WriteLine("Do you want to translate again?(Y/N): ");
                var newPlay = Console.ReadLine();

                if (newPlay == "N" || newPlay == "n")
                {
                    translateAgain = false;
                    Console.WriteLine("Thank You for translating");

                }else if (newPlay == "Y" || newPlay == "y")
                {
                    translateAgain = true;
                } */
            
                Console.WriteLine("Press any key to terminate");
                Console.ReadKey();
        }
    }
}
