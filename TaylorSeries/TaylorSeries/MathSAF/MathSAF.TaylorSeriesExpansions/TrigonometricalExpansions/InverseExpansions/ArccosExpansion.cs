using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.ReverseTrigonometricalExpansions
{
    class ArccosExpansion : ITaylorExpansion
    {
        private double error;
        private double x;
        private bool isSpecialCase;

        public ArccosExpansion(double error, double x)
        {
            this.error = error;
            if (x > 1 || x < -1)
            {
                throw new ArgumentOutOfRangeException("x", "Argument out of bounds. X can be only [-1;1]");
            }
            isSpecialCase = x == -1;
            this.x = (Math.Pow(1-x*x, 0.5))/(1+x);
        }

        public Result Calculate()
        {
            Result res;
            if (isSpecialCase)
            {
                res = new Result();
                res.Answer = Math.PI;
                return res;
            }
            ArctgExpansion arctg = new ArctgExpansion(error * 0.1, x);
            res = arctg.Calculate();
            res.Answer *= 2;
            return res;
        }
    }
}
