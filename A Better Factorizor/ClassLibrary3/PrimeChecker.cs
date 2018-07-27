using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PrimeChecker
    {

        private bool IsPrime(int UserNum)
        {
            bool isPrime = true;

            for (int i = 2; i < UserNum; i++)
            {
                if (UserNum % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }

        public bool GetPrime(int UserNum)
        {
            bool returnPrime = IsPrime(UserNum);
            return returnPrime;
        }
}
}
