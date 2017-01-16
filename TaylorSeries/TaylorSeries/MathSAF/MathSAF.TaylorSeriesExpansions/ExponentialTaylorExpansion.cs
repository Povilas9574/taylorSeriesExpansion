using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluationAPI;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;
using TaylorSeries.MathSAF.MathSAF.Helpers;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluation;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions
{
    class ExponentialTaylorExpansion : ITaylorExpansion
    {
        private double error;
        private double pow = 1;
        private IErrorEvaluator evaluator = new ErrorEvaluator();
        private FactorialHelper factorial = new FactorialHelper();

        public ExponentialTaylorExpansion(double error, double pow)
        {
            this.error = error;
            this.pow = pow;
        }

        public ExponentialTaylorExpansion(double error)
        {
            this.error = error;
        }

        public Result Calculate()
        {
            double expBase;
            double m;
            Result result = new Result();
            int n;
            double res = 0;

            if(pow >= 1)
            {
                expBase = 3;
            }
            else if(pow < 0)
            {
                expBase = 2.5;
            } 
            else
            {
                result.Answer = 1;
                return result;
            }

            m = Math.Pow(expBase, pow);
            n = evaluator.Evaluate(m, error, pow);

            for (int i = 0; i <= n; i++)
            {
                res += (Math.Pow(pow, i)/factorial.CalculateFactNoRecursion(i));
            }

            result.Answer = res;
            return result;
        }
        

    }
}
