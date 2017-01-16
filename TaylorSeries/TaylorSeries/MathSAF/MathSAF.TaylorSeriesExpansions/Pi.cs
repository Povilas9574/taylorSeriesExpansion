using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluationAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions
{
    class Pi : ITaylorExpansion
    {
        private IErrorEvaluator evaluator;// = new Evaluator();
        private double _error;
        public Pi(double error, IErrorEvaluator Evaluator)
        {
            evaluator = Evaluator;
            _error = error;
        }
        public Result Calculate()
        {
            Result r = new Result();
            double result = 1;
            int n = evaluator.Evaluate(3.15, _error, 1);
            for (int i = 1; i <= n; i++)
            {
                result += Math.Pow(-1, i % 2) * 1 / (1 + (2 * i));
            }
            result *= 4;
            r.Answer = result;
            //System.Windows.Forms.MessageBox.Show(result.ToString());
            return r;
        }
    }
}
