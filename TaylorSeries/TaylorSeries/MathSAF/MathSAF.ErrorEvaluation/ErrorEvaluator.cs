using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluationAPI;

namespace TaylorSeries.MathSAF.MathSAF.ErrorEvaluation
{
    public class ErrorEvaluator : IErrorEvaluator
    {
        public int Evaluate(double m, double error, double x)
        {
            Helpers.FactorialHelper factorial = new Helpers.FactorialHelper();
            int n=1;
            while (true)
            {
                if ((m * Math.Pow(Math.Abs(x), n + 1)) / factorial.CalculateFactorial(n + 1) <= error)
                {
                    return n;
                }
                n++;
            }
        }
    }
}
