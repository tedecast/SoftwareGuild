using System;

namespace BattleShip.BLL.Requests
{
    public class Coordinate
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Coordinate(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public override bool Equals(object obj)
        {
            Coordinate otherCoordinate = obj as Coordinate;

            if (otherCoordinate == null)
                return false;

            return otherCoordinate.XCoordinate == this.XCoordinate &&
                   otherCoordinate.YCoordinate == this.YCoordinate;
        }

        public override int GetHashCode()
        {
            string uniqueHash = this.XCoordinate.ToString() + this.YCoordinate.ToString() + "00";
            return (Convert.ToInt32(uniqueHash));
        }

        public static int ConvertXCoords(string coords)
        {
            int xcoord = 0;
            int ycoord = 0;
            string actual_num;
            string[] numbered_letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            char letter_char = coords[0];
            letter_char = Char.ToUpper(letter_char);
            string letter_string = letter_char.ToString();

            if (coords.Length == 3)
            {
                char[] number = { coords[1], coords[2] };
                actual_num = new string(number);
                int.TryParse(actual_num, out ycoord);

            }
            else
            {
                char[] number = { coords[1] };
                actual_num = new string(number);
                int.TryParse(actual_num, out ycoord);
            }

            for (int i = 0; i < 10; i++)
            {
                if (numbered_letters[i] == letter_string)
                {
                    xcoord = i + 1;
                }
            }

            return xcoord;
        }

        public static int ConvertYCoords(string coords)
        {
            int ycoord = 0;
            string actual_num;
            if (coords.Length == 3)
            {
                char[] number = { coords[1], coords[2] };
                actual_num = new string(number);
                int.TryParse(actual_num, out ycoord);

            }
            else
            {
                char[] number = { coords[1] };
                actual_num = new string(number);
                int.TryParse(actual_num, out ycoord);
            }

            return ycoord;
        }

    }
}
