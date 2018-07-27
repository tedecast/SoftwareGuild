using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.UI;

namespace Factorizor.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorizorWorkFlow operation = new FactorizorWorkFlow();
            operation.Factorize();
        }
    }
}
