using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        public static string GetUserName()
        {
            Console.WriteLine("Enter Player's name: ");
            string username = Console.ReadLine();
            Console.Clear();

            return username;
        }

        public static string GetUserCoordinates()
        {
            Console.WriteLine("Choose a valid coordinate."); 
            Console.WriteLine("A1 - J10");

            string coord = Console.ReadLine();
            return coord;
        }

        public static string GetDirection()
        {
            Console.WriteLine("Place your ship in a valid direction.");
            Console.WriteLine("Up, Down, Left or Right");

            string direction = Console.ReadLine();
            return direction;
        }

        public static bool GameOver()
        {
            Console.WriteLine("Do you want to play again? Y/N");
            string gameover = Console.ReadLine();
            
            if (gameover[0] == 'Y' || gameover[0] == 'y')
            {
                GameWorkflow.StartGame();
            }

            return true;
        }

    }
}
