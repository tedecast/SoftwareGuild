using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;
using NUnit.Framework;

namespace Factorizor.Tests
{   
    [TestFixture]
    public class FactorizorTests
    {
        [Test]
        public void BigArray()
        {
            FactorFinder factorInstance = new FactorFinder();
            int[] actual = factorInstance.Factors(6);
            int[] array = new int [4]{ 1, 2, 3, 6 };

            Assert.AreEqual(array, actual);
        }

        [Test]
        public void SmallArray()
        {
            FactorFinder factorInstance = new FactorFinder();
            int[] actual = factorInstance.Factors(7);
            int[] array = new int[2] { 1, 7 };

            Assert.AreEqual(array, actual);
        }

        [Test]
        public void BigNumber()
        {
            FactorFinder factorInstance = new FactorFinder();
            int[] actual = factorInstance.Factors(6001);
            int[] array = new int[4] { 1, 17, 353, 6001 };

            Assert.AreEqual(array, actual);
        }


        [Test]
        public void PerfectNum()
        {
            PerfectChecker _PerfCheckInstance = new PerfectChecker();
            bool actual = _PerfCheckInstance.obtainPerf(6);
            bool isPerfect = true;

            Assert.AreEqual(isPerfect, actual);
        }

        [Test]
        public void NotPerfectNum()
        {
            PerfectChecker _PerfCheckInstance = new PerfectChecker();
            bool actual = _PerfCheckInstance.obtainPerf(7);
            bool isPerfect = false;

            Assert.AreEqual(isPerfect, actual);
        }

        [Test]
        public void BigPerfectNum()
        {
            PerfectChecker _PerfCheckInstance = new PerfectChecker();
            bool actual = _PerfCheckInstance.obtainPerf(33550336);
            bool isPerfect = true;

            Assert.AreEqual(isPerfect, actual);
        }

        [Test]
        public void isPrime()
        {
            PrimeChecker PrimeCheckInstance = new PrimeChecker();
            bool actual = PrimeCheckInstance.GetPrime(7);
            bool isPrime = true;

            Assert.AreEqual(isPrime, actual);
        }

        public void NotPrime()
        {
            PrimeChecker PrimeCheckInstance = new PrimeChecker();
            bool actual = PrimeCheckInstance.GetPrime(6);
            bool isPrime = false;

            Assert.AreEqual(isPrime, actual);
        }

        public void BigPrime()
        {
            PrimeChecker PrimeCheckInstance = new PrimeChecker();
            bool actual = PrimeCheckInstance.GetPrime(101);
            bool isPrime = true;

            Assert.AreEqual(isPrime, actual);
        }
    }
}
