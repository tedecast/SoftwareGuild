using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class Player
    {
        public string Name { get; set; }
        public string Coordinate { get; set; }

        public Player Opponent { get; set; }

        public Board Board { get; set; }

        public Player()
        {
            Board = new Board();
        }



    }
}
