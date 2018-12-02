using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{

    public class GameWorkflow
    {
        public static void StartGame()
        {

            bool gameOver = false;

            ConsoleOutput.Welcome();

            Player p1 = new Player();
            Player p2 = new Player();
            

            p1.Name = ConsoleInput.GetUserName();
            p2.Name = ConsoleInput.GetUserName();
            SetupWorkflow setup = new SetupWorkflow();
            setup.BoardSetup(p1.Board, p1.Name, p2.Name, p2.Board);
            p1.Opponent = p2;
            p2.Opponent = p1;
            int player_turn = ConsoleOutput.FirstTurnGenerator(p1, p2);

            while (!gameOver)
            {
                if (player_turn == 1)
                {
                    player_turn = 0;

                    //draw the user board
                    Console.WriteLine("");
                    Console.WriteLine("It is now {0}'s turn.", p1.Name);
                    ConsoleOutput.DrawHistoryBoard(p1.Opponent);
                    Console.WriteLine("Displaying shots fired on {0}'s ship map", p2.Name);
                    Console.WriteLine("");
                    string coord_string = ConsoleInput.GetUserCoordinates();
                    Coordinate coord = new Coordinate(Coordinate.ConvertXCoords(coord_string), Coordinate.ConvertYCoords(coord_string));
                    var response = p1.Opponent.Board.FireShot(coord);

                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Invalid:
                            ConsoleOutput.DisplayInvalid();
                            player_turn = 1;
                            break;
                        case ShotStatus.Duplicate:
                            ConsoleOutput.DisplayDuplicate();
                            player_turn = 1;
                            break;
                        case ShotStatus.Miss:
                            ConsoleOutput.DisplayMiss();
                            break;
                        case ShotStatus.Hit:
                            ConsoleOutput.DisplayHit(response.ShipImpacted);
                            break;
                        case ShotStatus.HitAndSunk:
                            ConsoleOutput.DisplayHitandSunk(response.ShipImpacted);
                            break;
                        case ShotStatus.Victory:
                            ConsoleOutput.DisplayVictory(response.ShipImpacted);
                            gameOver = ConsoleInput.GameOver();
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Clear the screen with spacebar");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    player_turn = 1;

                    Console.WriteLine("");
                    Console.WriteLine("It is now {0}'s turn.", p2.Name);
                    ConsoleOutput.DrawHistoryBoard(p2.Opponent);
                    Console.WriteLine("Displaying shots fired on {0}'s ship map", p1.Name);
                    Console.WriteLine("");
                    string coord_string = ConsoleInput.GetUserCoordinates();
                    Coordinate coord = new Coordinate(Coordinate.ConvertXCoords(coord_string), Coordinate.ConvertYCoords(coord_string));
                    var response = p2.Opponent.Board.FireShot(coord);

                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Invalid:
                            ConsoleOutput.DisplayInvalid();
                            player_turn = 0;
                            break;
                        case ShotStatus.Duplicate:
                            ConsoleOutput.DisplayDuplicate();
                            player_turn = 0;
                            break;
                        case ShotStatus.Miss:
                            ConsoleOutput.DisplayMiss();
                            break;
                        case ShotStatus.Hit:
                            ConsoleOutput.DisplayHit(response.ShipImpacted);
                            break;
                        case ShotStatus.HitAndSunk:
                            ConsoleOutput.DisplayHitandSunk(response.ShipImpacted);
                            break;
                        case ShotStatus.Victory:
                            ConsoleOutput.DisplayVictory(response.ShipImpacted);
                            gameOver = ConsoleInput.GameOver() ;
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Clear the screen with spacebar");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

        }
    }
}

