using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.ReverseTrigonometricalExpansions
{
    class ArcctgExpansion : ITaylorExpansion
    {
        private double error;
        private double x;
        private ArctgExpansion arctg;

        public ArcctgExpansion(double error, double x)
        {
            this.error = error;
            this.x = x;
            arctg = new ArctgExpansion(error, 1/x);
        }

        public Result Calculate()
        {
            return arctg.Calculate();
        }
    }
}
