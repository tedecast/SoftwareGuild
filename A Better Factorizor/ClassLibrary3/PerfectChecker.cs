using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Factorizor.BLL
{
    public class PerfectChecker
    {
        private bool IsPerfect(int userNum, int[] perfectCheck)
        {
            bool isPerfect = false;
            int perfectAddition = 0;

            for (int i = 0; i < perfectCheck.Length-1; i++)
            {
                perfectAddition += perfectCheck[i];
            }

            if (userNum == perfectAddition)
            {
                isPerfect = true;
            }
            return isPerfect;
        }

        public bool obtainPerf(int userNum)
        {
            FactorFinder Finder = new FactorFinder();

            int[] perfectCheck =  Finder.Factors(userNum);
            bool returnPerf = IsPerfect(userNum, perfectCheck);
            return returnPerf;
        }
    }
}

