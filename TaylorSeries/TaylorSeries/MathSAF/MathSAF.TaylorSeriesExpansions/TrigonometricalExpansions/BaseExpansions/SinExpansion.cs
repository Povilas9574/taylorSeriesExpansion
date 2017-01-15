using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.BaseExpansions
{
    class SinExpansion : ITaylorExpansion
    {
        public SinExpansion(double x, double error)
        {
            Number = x;
            Error = error;
        }

        private double Number
        {
            set;
            get;
        }
        private double Error
        {
            set;
            get;
        }

        public Result Calculate()
        {
            return new Result();
        }
    }
}
