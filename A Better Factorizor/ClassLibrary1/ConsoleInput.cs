using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class ConsoleInput
    {
        public static int GetNumFromUser()
        {
            Console.Clear();
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
}
