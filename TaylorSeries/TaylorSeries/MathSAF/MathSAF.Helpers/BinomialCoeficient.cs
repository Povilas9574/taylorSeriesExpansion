using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.MathSAF.MathSAF.Helpers
{
    class BinomialCoeficient
    {

        public double CountBinomialCoeficient(int top, int bottom) {

            FactorialHelper fact = new FactorialHelper();
            return fact.CalculateFactorial(top) / (fact.CalculateFactorial(bottom) * fact.CalculateFactorial(top - bottom));
        }
    }
}
