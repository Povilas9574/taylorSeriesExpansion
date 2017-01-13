using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.MathSAF.MathSAF.Helpers
{
    class BernulliNumbers
    {

        private BinomialCoeficient binomialCoefCalc;
        private double sum = 0.0;
        public BernulliNumbers() {
            binomialCoefCalc = new BinomialCoeficient();
        }
        public double BernulliNumber(int n)
        {
            

            if (n == 0)
            {
                return 1;
            }
            else
            {
                
                for (int k = 1; k <= n; k++)
                {
                   sum = sum + ( binomialCoefCalc.CountBinomialCoeficient(n + 1, k + 1) * BernulliNumber(n - k));//TODO: cia klaida kazkur
                }
                return ((-1 /( n + 1)) * sum);
            }
        }


    }
}
