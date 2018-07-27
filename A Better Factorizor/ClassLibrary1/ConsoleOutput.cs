using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace Factorizor.UI
{
    class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Better, Testable, Factorizor!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
        }

        public static void DisplayFactor(int[] factors)
        {
            FactorFinder Finder = new FactorFinder();
            Console.WriteLine("The factors of your number are " + string.Join(", ", factors));
        }

        public static void DisplayPerfect(int userNum)
        {
            Console.WriteLine(userNum + " is a perfect number.");
        }

        public static void DisplayNotPerfect(int userNum)
        {
            Console.WriteLine(userNum + " is not a perfect number.");
        }

        public static void DisplayPrime(int userNum)
        {
            Console.WriteLine(userNum + " is a prime number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void DisplayNotPrime(int userNum)
        {
            Console.WriteLine(userNum + " is not a prime number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void DisplayInvalid()
        {
            Console.WriteLine("That input wasn't valid, try something greater than 0.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
