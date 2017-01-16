using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.MathSAF.MathSAF.Helpers
{
    class FactorialHelper
    {
        public long CalculateFactorial(long x)
        {
            if ((x == 0) || (x == 1))
            {
                return 1;
            }
            else
            {
                return x * CalculateFactorial(x - 1);
            }
        }

        public long CalculateFactNoRecursion(long x)
        {
            long result = 1;
            for (long i = 1; i <= x; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
}
