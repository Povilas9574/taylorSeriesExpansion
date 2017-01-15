using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;
using TaylorSeries.MathSAF.MathSAF.Helpers;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.ReverseTrigonometricalExpansions
{
    class ArcsinExpansion : ITaylorExpansion
    {
        private double error;
        private double x;
        private bool xNegative;

        public ArcsinExpansion(double error, double x)
        {
            this.error = error;
            if(x > 1 || x < -1)
            {
                throw new ArgumentOutOfRangeException("x", "Argument out of bounds. X can be only [-1;1]");
            }
            xNegative = x < 0;
            x *= -1;
            this.x = x/(1 + Math.Pow(1-x, 0.5));
        }

        public Result Calculate()
        {
            Result res;
            ArctgExpansion arctg = new ArctgExpansion(error * 0.1, x);
            res = arctg.Calculate();
            res.Answer *= xNegative ? -2 : 2;
            return res;
        }
    }
}
