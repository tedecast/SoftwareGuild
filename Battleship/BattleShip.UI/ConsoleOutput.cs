using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        public static void Welcome()
        {
            Console.WriteLine("WELCOME TO BATTLESHIP");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static int FirstTurnGenerator(Player p1 , Player p2)
        {
            Random rand = new Random();
            int intRand = rand.Next(1, 3);


            if (intRand == 1)
            {
                Console.WriteLine("{0} will start.", p1.Name);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("{0} will start.", p2.Name);
                Console.ReadKey();
            }

            return intRand;
        }

        public static void DrawInitialBoard()
        {
            Console.WriteLine("");
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine(" A - - - - - - - - - - ");
            Console.WriteLine(" B - - - - - - - - - - ");
            Console.WriteLine(" C - - - - - - - - - - ");
            Console.WriteLine(" D - - - - - - - - - - ");
            Console.WriteLine(" E - - - - - - - - - - ");
            Console.WriteLine(" F - - - - - - - - - - ");
            Console.WriteLine(" G - - - - - - - - - - ");
            Console.WriteLine(" H - - - - - - - - - - ");
            Console.WriteLine(" I - - - - - - - - - - ");
            Console.WriteLine(" J - - - - - - - - - - ");
            Console.WriteLine("");

        }

        public static void DrawHistoryBoard(Player player)
        {
            for (int i = 1; i < 11; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
                }
                bool isFirstInRow = true;

                for (int j = 1; j < 11; j++)
                {
                    string[] numbered_letters = { " A", " B", " C", " D", " E", " F", " G", " H", " I", " J" };
                    if (isFirstInRow)
                    {
                        Console.Write(numbered_letters[i-1]);
                        isFirstInRow = false;
                    }
                    Coordinate drawing_coord = new Coordinate(i,j);
                    var response = player.Board.CheckCoordinate(drawing_coord);

                    switch (response)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Unknown:
                            Console.Write(" -");
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" M");
                            Console.ResetColor();
                            break;

                    }
                }
                Console.WriteLine();
            }
        }

        public static void DisplayNotEnoughSpace()
        {
            Console.WriteLine();
            Console.WriteLine("You've run aground! Place the ship with a coordinate and direction in the ocean.");
            Console.WriteLine("Press any key to replace your ship.");
            Console.ReadKey();
        }

        public static void DisplayOverLap()
        {
            Console.WriteLine();
            Console.WriteLine("Your ships will crash into each other if you stay to that course!");
            Console.WriteLine("Chart another path by entering another coordinate and direction!");
            Console.WriteLine("Press any key to replace your ship.");
            Console.ReadKey();
        }

        public static void DisplayOk()
        {
            Console.WriteLine();
            Console.WriteLine("Your ship is charted and ready for battle.");
            Console.WriteLine("Press any key to place your next ship.");
            Console.ReadKey();
        }

        public static void DisplayInvalid()
        {
            Console.WriteLine();
            Console.WriteLine("That was an invalid coordinate please enter another one.");
        }

        public static void DisplayDuplicate()
        {
            Console.WriteLine();
            Console.WriteLine("That was an duplicate coordinate please enter another one.");
        }

        public static void DisplayMiss()
        {
            Console.WriteLine();
            Console.WriteLine("Your missile sinks into the ocean. That coordinate was a miss.");
        }

        public static void DisplayHit(string ShipImpacted)
        {
            Console.WriteLine();
            Console.WriteLine("Your missile explodes into one of your opponent's ship! Well done.");
        }

        public static void DisplayHitandSunk(string ShipImpacted)
        {
            Console.WriteLine();
            Console.WriteLine("Your missile explodes into the {0}'s remaining support! The ship is sunk.", ShipImpacted);
        }

        public static void DisplayVictory(string ShipImpacted)
        {
            Console.WriteLine();
            Console.WriteLine("Your missile explodes into the {0}'s remaining support! The final ship is sunk." , ShipImpacted);
            Console.WriteLine(" You are the winner!");
        }

    }
}
