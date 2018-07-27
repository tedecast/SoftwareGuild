using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorFinder
    {
        public int[] Factors(int userNum)
        {
            int length = 0;

            for (int i = 1; i <= userNum; i++)
            {
                if (userNum % i == 0)
                {
                    length++;
                }
            }

            int[] factors = new int[length];
            int count = 0;

            for (int i = 1; i <= userNum; i++)
            {
                if (userNum % i == 0)
                {
                    factors[count] = i;
                    count++;
                }
            }

            return factors;
        }
    }
}
