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
            Helpers.FactorialHelper factorial = new Helpers.FactorialHelper();
            int n = 1;
            while (true)
            {
                if ((Math.Pow(Math.Abs(Number), (2 * n + 3))) / factorial.CalculateFactorial(2 * n + 3) <= Error)
                {
                    break;
                }
                n++;
            }
            Result result = new Result();
            result.Exist = true;
            result.Answer = 0;
            for (int i = 0; i <= n; i++)
            {
                result.Answer = result.Answer + (Math.Pow(-1, i) * Math.Pow(Number, 2 * i + 1))/ factorial.CalculateFactorial(2 * i +1);
            }

            return result;
        }
    }
}
