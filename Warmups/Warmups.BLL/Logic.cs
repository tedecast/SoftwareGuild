using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool goodTime = false;

            if (cigars >= 40 && isWeekend == true)
            {
                goodTime = true;
            }
            else if (cigars >= 40 && cigars <= 60 && !isWeekend)
            {
                goodTime = true;
            }

            return goodTime;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int gotTable = 0;

            if (yourStyle + dateStyle >= 15)
            {
                gotTable = 2;
            }
            else if (yourStyle + dateStyle >= 10)
            {
                gotTable = 1;
            }

            return gotTable;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool Outside = false;

            if (temp >= 60 && temp <= 90 && isSummer == false)
            {
                Outside = true;
            }
            else if (temp >= 60 && temp <= 100 && isSummer)
            {
                Outside = true;
            }

            return Outside;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int ticket = 0;
            int minspeed = 60;
            int middlefirst = 61;
            int middlelast = 81;

            if (isBirthday)
            {
                minspeed += 5;
                middlefirst += 5;
                middlelast += 5;
            }
            if (speed <= minspeed)
            {
                ticket = 0;
            }
            else if (speed >= middlefirst && speed <= middlelast)
            {
                ticket = 1;
            }
            else
            {
                ticket = 2;
            }

            return ticket;
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;

            if (sum >= 10 && sum <= 19)
            {
                sum = 20;
            }

            return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string time = "";

            if (day > 0 && day < 6 && !vacation)
            {
                time = "7:00";
            }
            else if (day == 0 || day == 1 && !vacation)
            {
                time = "10:00";
            }
            else if (day > 0 && day < 6 && vacation)
            {
                time = "10:00";
            }
            else
            {
                time = "off";
            }

            return time;
        }
        
        public bool LoveSix(int a, int b)
        {
            bool isSix = false;

            if (a == 1 || a == 6)
            {
                isSix = true;
            }
            else if (b == 1 || b == 6)
            {
                isSix = true;
            }
            else if ((a + b) == 6 || (a - b) == 6)
            {
                isSix = true;
            }

            return isSix;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            bool isRange = false;

            if (outsideMode)
            {
                if (n <= 1 || n >= 10)
                {
                    isRange = true;
                }
            }
            else 
            {
                if (n >= 1 && n <= 10 )
                {
                    isRange = true;
                }
            }
            return isRange;
        }
        
        public bool SpecialEleven(int n)
        {
            bool special = false;

            if (n % 11 == 0 || (n - 1) % 11 == 0)
            {
                special = true;
            }

            return special;
        }
        
        public bool Mod20(int n)
        {
            bool isMod = false;

            if ((n - 1) % 20 == 0 || (n - 2) % 20 == 0)
            {
                isMod = true;
            }

            return isMod;
        }
        
        public bool Mod35(int n)
        {
            bool is3 = false;
            bool is5 = false;
            bool isMod = false;

            if (n % 3 == 0)
            {
                is3 = true;
            }
            if (n % 5 == 0)
            {
                is5 = true;
            }

            if ((is3 && !is5) || (!is3 && is5))
            {
                isMod = true;
            }

            return isMod;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            bool pickUp = false;

            if (isMorning && isMom)
            {
                pickUp = true;
            }
            else if (!isMorning && !isAsleep)
            {
                pickUp = true;
            }

            return pickUp;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            bool isEqual = false;

            if (a + b == c)
            {
                isEqual = true;
            }
            else if (a + c == b)
            {
                isEqual = true;
            }
            else if (b + c == a)
            {
                isEqual = true;
            }

            return isEqual;

        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool inOrder = false;

            if (bOk)
            {
                if (c > b)
                {
                    inOrder = true;
                }
            }
            else if (!bOk)
            {
                if (b > a && c > b)
                {
                    inOrder = true;
                }
            }

            return inOrder;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool inOrder = false;

            if (equalOk)
            {
                if (b >= a && c >= b)
                {
                    inOrder = true;
                }
            }
            else if (!equalOk)
            {
                if (b > a && c > b)
                {
                    inOrder = true;
                }
            }

            return inOrder;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            bool isDigit = false;
            
            if (a > 20)
            {
                a -= 20;
            }
            if (c > 10)
            {
                c -= 10;
            }

            if (a == c)
            {
                isDigit = true;
            }

            return isDigit;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = 0;

            if (noDoubles)
            {
                if (die1 == die2)
                {
                    sum = die1 + die2 + 1;
                }
                else
                {
                    sum = die1 + die2;
                }
            }
            else {
                sum = die1 + die2;
            }
            return sum;
        }


    }
}
