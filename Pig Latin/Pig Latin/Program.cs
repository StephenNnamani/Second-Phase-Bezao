using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

                Console.WriteLine("Type in the words you want to Translate here: \n \n");
                Comments = Console.ReadLine();


                foreach (string letters in Comments.Split(' '))
                {
                    string firstLetter = letters.Substring(0, 1);
                    //Console.WriteLine(firstLetter);
                    string restOfWord = letters.Substring(1, letters.Length - 1);

                    string Converted = restOfWord+firstLetter+ay + " ";

                    var lowerCase = Converted.ToLower();
                    var r = new Regex(@"(^[a-z])|\.\s+", RegexOptions.ExplicitCapture);
                    var result = r.Replace(lowerCase, s => s.Value.ToUpper());
                    Console.Write(result);

                }

                Console.WriteLine(@"
===========================================================
Do you want to translate this word back to English? (Y/N)
===========================================================
");
                string answer = Console.ReadLine();
                
                if (answer == "Y" || answer == "y")
                {
                    Console.WriteLine(Comments);
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
            }
            Console.WriteLine("Press any key to terminate");
            Console.ReadKey();
        }
    }
}
