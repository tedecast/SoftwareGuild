using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            bool trouble = false;
            if ((aSmile && bSmile) || (!aSmile && !bSmile))
            {
                trouble = true;
            }

            return trouble;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            bool sleepIn = false;
            if (!isWeekday || isVacation)
            {
                sleepIn = true;
            }

            return sleepIn;
        }

        public int SumDouble(int a, int b)
        {
            int sum = 0;
            sum = a + b;

            if (a == b)
            {
                sum *= 2;
            }

            return sum;
        }
        
        public int Diff21(int n)
        {
            int num = 0;
            num = Math.Abs(n - 21);

            if (n > 21)
            {
                num *= 2;
            }

            return num;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool inTrouble = false;
            if (isTalking && (hour < 7 || hour > 20))
            {
                inTrouble = true;
            }

            return inTrouble;
        }
        
        public bool Makes10(int a, int b)
        {
            bool ten = false;
            if ((a == 10 || b == 10) || (a+b == 10))
            {
                ten = true;
            }

            return ten;
        }
        
        public bool NearHundred(int n)
        {
            bool close = false;
            
            if (Math.Abs(n - 100) <= 10 || Math.Abs(n - 200) <= 10)
            {
                close = true;
            }

            return close;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            bool isPosNeg = false;
            if (!negative)
            {
                if (a < 0 || b < 0)
                {
                    isPosNeg = true;
                }
            }
            else
            {
                if (a < 0 && b < 0)
                {
                    isPosNeg = true;
                }
            }
            
            return isPosNeg;
        }
        
        public string NotString(string s)
        {
            if (s[0] != 'n')
            {
                s = "not " + s;
            }

            return s;
        }
        
        public string MissingChar(string str, int n)
        {
            str = str.Remove(n, 1);

            return str;
        }
        
        public string FrontBack(string str)
        {
            string end;
            string front;

            if (str.Length > 2)
            {
                end = str.Substring(str.Length-1);
                str = str.Remove(str.Length -1);
                
                front = str.Substring(0,1);
                str = str.Remove(0,1);

                str = end + str + front;
            }
            else if (str.Length == 2)
            {
                end = str.Substring(str.Length - 1);
                str = str.Remove(str.Length - 1);

                front = str.Substring(0, 1);
                str = str.Remove(0, 1);

                str = end + front;
            }

            return str;
        }
        
        public string Front3(string str)
        {
            if (str.Length >= 3)
            {
                str = str.Substring(0, 3);
            }
            else
            {
                str = str.Substring(0, 2);
            }

            return str + str + str;
        }
        
        public string BackAround(string str)
        {
            string endchar = str.Substring(str.Length - 1);

            return endchar + str + endchar;
        }
        
        public bool Multiple3or5(int number)
        {
            bool isMultiple = false;

            if (number % 3 == 0 || number % 5 == 0)
            {
                isMultiple = true;
            }

            return isMultiple;
        }
        
        public bool StartHi(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            else if (str.Length > 2)
            {
                if (str[2] == 'g' || str[2] == 'p')
                {
                    return false;
                }
            }


            string start = str.Substring(0, 2);
            return start.Equals("hi");
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            bool icy = false;
            bool hot = false;
            bool icyhot = false;

            if (temp1 < 1 || temp2 < 1)
            {
                icy = true;
            }

            if (temp1 > 100 || temp2 > 100)
            {
                hot = true;
            }

            if (icy && hot)
            {
                icyhot = true;
            }

            return icyhot;
        }
        
        public bool Between10and20(int a, int b)
        {
            bool isBetween = false;

            if ((a >= 10 && a <= 20) || (b >= 10 && b <= 20))
            {
                isBetween = true;
            }

            return isBetween;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            bool isTeen = false;

            if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19) || (c >= 13 && c <= 19))
            {
                isTeen = true;
            }

            return isTeen;
        }
        
        public bool SoAlone(int a, int b)
        {
            bool isAlone = false;
            bool aTeen = false;
            bool bTeen = false;


            if (a >= 10 && a <= 20)
            {
                aTeen = true;
            }
            if (b >= 10 && b <= 20)
            {
                bTeen = true;
            }

            if (aTeen && !bTeen || !aTeen && bTeen)
            {
                isAlone = true;
            }

             return isAlone;
        }
        
        public string RemoveDel(string str)
        {
               if(str.Contains("del"))
               {
                   int indexof = str.IndexOf("del");
                   str = str.Remove(indexof, indexof+2);
               }

               return str;
        }
        
        public bool IxStart(string str)
        {
            bool isIx = false;
            if (str[1] == 'i' && str[2] == 'x')
            {
                isIx = true;
            }

            return isIx;
        }
        
        public string StartOz(string str)
        {
            if (str.Length < 2)
            {
                str = "";
            }
            else if (str[0] == 'o' && str[1] == 'z')
            {
                str = "oz";
            }
            else if (str[0] == 'o')
            {
                str = "o";
            }
            else if (str[1] == 'z')
            {
                str = "z";
            }


            return str;

        }
        
        public int Max(int a, int b, int c)
        {
            int greatest = 0;

            if (a > b && a > c)
            {
                greatest = a;
            }
            else if (b > a && b > c)
            {
                greatest = b;
            }
            else 
            {
                greatest = c;
            }

            return greatest;
        }
        
        public int Closer(int a, int b)
        {
            if (Math.Abs(10-a) < Math.Abs(10-b))
            {
                return a;
            }
            else if (Math.Abs(10 - b) < Math.Abs(10 - a))
            {
                return b;
            }
            else
            {
                return 0;
            }
        }
        
        public bool GotE(string str)
        {
            bool isGotE = false;
            int eCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                {
                    eCount++;
                }
            }

            if (eCount <= 3 && str.Contains("e"))
            {
                isGotE = true;
            }

            return isGotE;
        }
        
        public string EndUp(string str)
        {


            if (str.Length > 3)
            {
                string last3 = str.Substring(str.Length - 3);
                str = str.Substring(0, str.Length - 3);
                str += last3.ToUpper();
            }
            else
            {
                str = str.ToUpper();
            }

            return str;

        }
        
        public string EveryNth(string str, int n)
        {
            string nth = "";

            for (int i = 0; i < str.Length; i += n)
            {
                nth += str[i];
            }

            return nth;
        }
    }
}
