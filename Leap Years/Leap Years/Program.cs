using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap_Years
{
    class Program
    {
        static void Main(string[] args)
        {
            var CurrentYear = 2022;
            var increment = 0;

            for (int i = 0; increment < 20; i++)
            {
                if (CurrentYear % 4 == 0)
                {
                    increment++;
                    Console.WriteLine($"The {increment} Leap year is: {CurrentYear}");
                    CurrentYear++;

                }
                else
                {
                    CurrentYear++;
                }
            }
            Console.ReadLine();
        }
    }
}
