using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.MathSAF.MathSAF.ErrorEvaluationAPI
{
    interface IErrorEvaluator
    {
        int Evaluate(double m, double error, double x);
    }
}
