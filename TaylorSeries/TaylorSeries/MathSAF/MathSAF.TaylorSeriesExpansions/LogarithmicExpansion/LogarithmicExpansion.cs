using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.LogarithmicExpansion
{
    class LogarithmicExpansion : ITaylorExpansion
    {
        public LogarithmicExpansion(double number, int repeatIndex)
        {
        }

        long RepeatIndex
        {
            set;
            get;
        }

        public Result Calculate()
        {
            throw new NotImplementedException();
        }

        private double CalculateNMember(int n)
        {
            return 0;
        }

        private double FindParameters(int n)
        {
            return 0;
        }

        private double AdditionFormula(double number)
        {
            double returningX = 0;

            return 0;
        }


    }
}
