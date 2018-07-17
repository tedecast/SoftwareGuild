using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string times = "";
            for (int i = 0; i < n; i++)
            {
                times += str; 
            }

            return times;
        }

        public string FrontTimes(string str, int n)
        {
            string fronttimes = str.Substring(0,3);
            string returnString = "";
           
            for (int i = 0; i < n; i++)
            {
                returnString += fronttimes;
            }

            return returnString;
        }

        public int CountXX(string str)
        {
            int xCount = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == 'x')
                xCount += 1;
            }

            return xCount;
        }

        public bool DoubleX(string str)
        {
            bool isDouble = false;


            int firstx = str.IndexOf('x');
            if (str.Length > 2)
            {
                for (int i = 0; i < str.Length-1; i++)
                    {
                        if (str[i] == 'x' && str[i + 1] == 'x' && i == firstx)
                        {
                            isDouble = true;
                            return isDouble;
                        }
                    }
                }

            return isDouble;
        }

        public string EveryOther(string str)
        {
            string everyOther = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    everyOther += str[i];
                }
            }

            return everyOther;
        }

        public string StringSplosion(string str)
        {

            string stringSplosion = "";

            for (int i = 0; i < str.Length; i++)
            {
                stringSplosion += str.Substring(0, i+1);
            }

            return stringSplosion;

        }

        public int CountLast2(string str)
        {
            string lasttwo = str.Substring(str.Length - 2);
            int counter = 0;

            for (int i = 0; i < str.Length-1; i++)
            {
                string check = "";
                check = str.Substring(0, 2);

                if (check == lasttwo)
                {
                    counter++;
                }

                str = str.Remove(0, 1);
            }

            return counter;
        }

        public int Count9(int[] numbers)
        {
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    counter++;
                }
            }

            return counter;
        }

        public bool ArrayFront9(int[] numbers)
        {
            bool is9 = false;

            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    is9 = true;
                }
            }

            return is9;
        }

        public bool Array123(int[] numbers)
        {
            bool is123 = false;

            for (int i = 0; i < numbers.Length-2; i++)
            {
                if (numbers[i] == 1 && numbers[i+1] == 2 && numbers[i+2] == 3)
                {
                    is123 = true;
                }
            }

            return is123;
        }

        public int SubStringMatch(string a, string b)
        {
            int counter = 0;
            int loopCount = a.Length;

            if (loopCount < 4)
            {
                loopCount = 4;
            }

            for (int i = 0; i < loopCount - 2; i++)
            {

                if (a[0] + a[1] == b[0] + b[1])
                {
                    counter++;
                }

                a = a.Remove(0, 1);
                b = b.Remove(0, 1);
            }

            return counter;
        }

        public string StringX(string str)
        {
            int len = str.Length;

            if (len < 3)
            {
                return str;
            }
            string subStr = str.Substring(1, len - 2);
            subStr = subStr.Replace("x", "");

            return str.Substring(0,1) + subStr + str.Substring(len - 1);
        }

        public string AltPairs(string str)
        {
            string newstr = "";

            for (int i = 0; i < str.Length; i+= 4)
            {
                if (i + 2 < str.Length)
                {
                    newstr += str.Substring(i, 2);
                }
                else
                {
                    newstr += str.Substring(i);
                }

            }

            return newstr;
        }

        public string DoNotYak(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i + 2 < str.Length && str[i] == 'y' && str[i + 2] == 'k')
                {
                    result = str.Remove(i, 3);
                    i += 2;
                }

            }

            return result;
        }

        public int Array667(int[] numbers)
        {
            int count = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && (numbers[i + 1] == 6 || numbers[i + 1] == 7))
                {
                    count++;
                }
            }

            return count;
        }

        public bool NoTriples(int[] numbers)
        {
            bool isTrip = true;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i] == numbers[i + 2])
                {
                    isTrip = false;
                }
            }

            return isTrip;
        }

        public bool Pattern51(int[] numbers)
        {
            bool isPattern = false;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if ((numbers[i] + 5 == numbers[i + 1]) && Math.Abs(numbers[i + 2] - (numbers[i] - 1)) <= 2)
                {
                    isPattern = true;
                }
            }

            return isPattern;
        }

    }
}
