using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace Factorizor.UI
{
    public class FactorizorWorkFlow
    {
        public void Factorize()
        {
            FactorFinder Finder = new FactorFinder();
            PerfectChecker _PerfCheck = new PerfectChecker();
            PrimeChecker _PrimeCheck = new PrimeChecker();

            ConsoleOutput.DisplayTitle();
            int userNum = ConsoleInput.GetNumFromUser();
            int[] factors = Finder.Factors(userNum);
            bool isPerfect = _PerfCheck.obtainPerf(userNum);
            bool isPrime = _PrimeCheck.GetPrime(userNum);

            ConsoleOutput.DisplayFactor(factors);
            if (isPerfect)
            {
                ConsoleOutput.DisplayPerfect(userNum);
            }
            else
                ConsoleOutput.DisplayNotPerfect(userNum);
            if (isPrime)
            {
                ConsoleOutput.DisplayPrime(userNum);
            }
            else
                ConsoleOutput.DisplayNotPrime(userNum);

        }
    }
}
