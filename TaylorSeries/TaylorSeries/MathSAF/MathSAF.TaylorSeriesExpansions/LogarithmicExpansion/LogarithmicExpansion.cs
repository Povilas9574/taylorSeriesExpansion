using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluation;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluationAPI;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.LogarithmicExpansion
{
    class LogarithmicExpansion : ITaylorExpansion
    {
        double Error
        {
            set;
            get;
        }
        double Number
        {
            set;
            get;
        }

        int RepeatIndex
        {
            set;
            get;
        }

        IErrorEvaluator evaluator = new ErrorEvaluator();

        public LogarithmicExpansion(double number, double error)
        {
            this.Error = error;
            this.Number = number;
        }


        public Result Calculate()
        {
            bool stop = false;
            Result result = new Result();
            double m = 1 / (1 + Number);
            double tempNumber = Number;
            int cycles = 0;
            RepeatIndex = evaluator.Evaluate(m, Error, Number);

            while (!stop)
            {
                if (tempNumber > 1 && tempNumber <= 2)
                {
                    tempNumber = tempNumber - 1;
                    double x = 1 / tempNumber;
                    result.Answer += CalculateOne(x);
                    stop = true;
                }
                if (tempNumber > 2)
                {
                    tempNumber = tempNumber - 1;
                    double x = 1 / tempNumber;
                    result.Answer += CalculateOne(x);
                }
                if (tempNumber < 1 && tempNumber > 0)
                {
                    double x = tempNumber - 1;
                    result.Answer += CalculateOne(x);
                    stop = true;
                }
                cycles++;
            }
            return result;
        }

        private double CalculateOne(double number)
        {
            double result = 0;
            for (int i = 1; i <= RepeatIndex+1; i++)
            {
                result += Math.Pow((-1), i - 1) * Math.Pow(number, i) / i;
            }
            return result;
        }



    }
}
