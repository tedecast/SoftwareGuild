using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    public class SetupWorkflow
    {


        public void BoardSetup(Board board1, string name1, string name2, Board board2)
        {
            Console.WriteLine("");
            Console.WriteLine("{0} place your ships on the board.", name1);
            Console.WriteLine("");
            PlaceShipsOnBoard(board1);
            Console.WriteLine("");
            Console.WriteLine("{0} place your ships on the board.", name2);
            Console.WriteLine("");
            PlaceShipsOnBoard(board2);

        }

        private void PlaceShipsOnBoard(Board board)
        {
            for (int i = 0; i < 5; i++)
            {
                PlaceShipRequest Ship = new PlaceShipRequest();

                //check for previously placed ships
                ConsoleOutput.DrawInitialBoard();
                string coord_string = ConsoleInput.GetUserCoordinates();
                string direction = ConsoleInput.GetDirection();

                if (direction.ToUpper() == "UP")
                {
                    Ship.Direction = ShipDirection.Up;
                }
                else if (direction.ToUpper() == "DOWN")
                {
                    Ship.Direction = ShipDirection.Down;
                }
                else if (direction.ToUpper() == "LEFT")
                {
                    Ship.Direction = ShipDirection.Left;
                }
                else if (direction.ToUpper() == "RIGHT")
                {
                    Ship.Direction = ShipDirection.Right;
                }

                Ship.ShipType = (ShipType)i;
                int x = Coordinate.ConvertXCoords(coord_string);
                int y = Coordinate.ConvertYCoords(coord_string);
                Ship.Coordinate = new Coordinate(x, y);

                    var response = board.PlaceShip(Ship);
                    switch (response)
                    {
                        case ShipPlacement.NotEnoughSpace:
                            ConsoleOutput.DisplayNotEnoughSpace();
                            i--;
                            break;

                        case ShipPlacement.Overlap:
                            ConsoleOutput.DisplayOverLap();
                            i--;
                            break;

                        case ShipPlacement.Ok:
                            ConsoleOutput.DisplayOk();
                            break;

                    }

                Console.Clear();
            }
        }
    }
}
