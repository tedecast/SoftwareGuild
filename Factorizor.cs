using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor 
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            int number;

            while (true)
            {
                Console.WriteLine("What number would you like to factor? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number) && number > 0)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Please enter a valid number");
                }

            }

            return number;
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            int product = number;
 
            Console.Write("The factors of " + product + " are:");

            for (int i = 1; i <= product; i++)
            {
                if (product % i == 0)
                {
                    Console.Write(" "+ i);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int perfect_num = 0;

            for (int i = 1; i < number; i++)
            {

                if (number % i == 0)
                {
                    perfect_num += i;
                }
            }

            if (perfect_num == number)
            {
                Console.WriteLine(number + " is a perfect number.");
            }

            else
            {
                Console.WriteLine(number + " is not a perfect number.");
            }

        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            bool isPrime = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                }

            }

            if(isPrime)
            {
                Console.WriteLine(number + " is a prime number.");

            }
            else
            {
                Console.WriteLine(number + " is not a prime number.");

            }
        }
    }
}