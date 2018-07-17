using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            bool isSix = false; 

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
                {
                    isSix = true;
                }
            }
            return isSix;
        }

        public bool SameFirstLast(int[] numbers)
        {
            bool isSame = false;

            if (numbers.Length > 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[0] == numbers[numbers.Length - 1])
                    {
                        isSame = true;
                    }
                }
            }
           
            return isSame;
        }
        public int[] MakePi(int n)
        {
            double pi = Math.PI;
            string str = pi.ToString().Remove(1, 1);
            char[] chararray = str.ToCharArray();
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {

                numbers[i] = int.Parse(chararray[i].ToString());
            }
            return numbers;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            bool sameEnd = false;

            if (a[a.Length - 1] == b[b.Length - 1] || a[0] == b[0])
            {
                sameEnd = true;
            }

            return sameEnd;
        }
        
        public int Sum(int[] numbers)
        {
            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }

            return total;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] newnumbers = new int[numbers.Length];

            for (int i = 1; i < numbers.Length; i++)
            {
                newnumbers[i-1] = numbers[i];
            }

            newnumbers[numbers.Length-1] = numbers[0];

            return newnumbers;

        }
        
        public int[] Reverse(int[] numbers)
        {
           int[] newnumbers = new int[numbers.Length];

           for (int i = 0; i < numbers.Length; i++)
           {
               newnumbers[i] = numbers[numbers.Length - i - 1];
           }

           return newnumbers;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int[] newnumbers = new int[numbers.Length];

            if (numbers[0] > numbers[numbers.Length-1])
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    newnumbers[i] = numbers[0];
                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    newnumbers[i] = numbers[numbers.Length-1];
                }
            }
            return newnumbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] newnumbers = new int[2];

            newnumbers[0] = a[1];
            newnumbers[1] = b[1];

            return newnumbers;
        }
        
        public bool HasEven(int[] numbers)
        {
            bool isEven = false;
            for (int i = 0; i < 2; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    isEven = true;
                }
            }
            return isEven;
        }
        
        public int[] KeepLast(int[] numbers)
        {

            int last = numbers[numbers.Length - 1];

            int[] newnumbers = new int[numbers.Length*2];
            newnumbers[newnumbers.Length - 1] = last;

            return newnumbers;
        }
        
        public bool Double23(int[] numbers)
        {
            bool isDouble = false;
            int isTwice = 0;

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        isTwice++;
                    }
                }
            }

            if (isTwice == 2)
            {
                isDouble = true;
            }
            return isDouble; 
        }
        
        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < 2; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                {
                    numbers[i + 1] = 0;
                }
            }

            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            bool unlucky = false;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 3)
                {
                    unlucky = true;
                }
            }

            return unlucky;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] newnums = new int[2];

            if (a.Length >= 2)
            {
                newnums[0] = a[0];
                newnums[1] = a[1];
            }
            else
            {
                if (a.Length == 1)
                {
                    newnums[0] = a[0];
                    newnums[1] = b[0];
                }
                else
                {
                    newnums[0] = b[0];
                    newnums[1] = b[1];
                }
            }

            return newnums;
        }

    }
}
