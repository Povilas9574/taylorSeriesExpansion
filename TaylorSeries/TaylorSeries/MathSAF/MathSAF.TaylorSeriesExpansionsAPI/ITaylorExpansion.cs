using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI
{
    interface ITaylorExpansion
    {
        Result Calculate(double error);
    }
}
