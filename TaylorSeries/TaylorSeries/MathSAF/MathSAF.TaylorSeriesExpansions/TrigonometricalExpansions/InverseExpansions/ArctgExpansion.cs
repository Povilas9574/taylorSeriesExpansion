using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluationAPI;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.ReverseTrigonometricalExpansions
{
    class ArctgExpansion : ITaylorExpansion
    {
        private double error;
        private double x;
        private Result res = new Result();

        public ArctgExpansion(double error, double x)
        {
            this.error = error;
            this.x = x;
        }

        public Result Calculate()
        {
            int n = 0;
            double r = 0;
            bool xNegative = (x < 0) ? true : false;
            bool xMoreThanOne;
            double tmpX = x;

            if(xNegative)
            {
                x *= -1;
            }
            
            xMoreThanOne = (x >= 1) ? true : false;
            x = xMoreThanOne ? 1 / x : x;

            while (!evaluate(n))
            {
                r += (Math.Pow(x, (2*n+1))) / (2*n+1) * Math.Pow(-1, n);
                n++;
            }

            x = xMoreThanOne ? tmpX : x;
            r = xMoreThanOne ? Math.PI/2 - r : r;

            if(xNegative)
            {
                x *= -1;
                r *= -1;
            }

            res.Answer = r;
            return res;
        }

        private bool evaluate(int n)
        {
            double err;

            err = Math.Pow(x, 2 * n + 1) / (2 * n + 1);
            if (err > error)
            {
                return false;
            }
            return true;
        }

        private double getNthMember(double x, int n)
        {
            int k;
            double result;

            if (n % 2 == 0)
            {
                k = 1;
            }
            else
            {
                k = -1;
            }

            result = Math.Pow(x, n * 2 + 1) / (n * 2 + 1) * k;
            return result;
        }
    }
}
