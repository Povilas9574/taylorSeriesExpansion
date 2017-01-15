using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaylorSeries.MathSAF.MathSAF.Helpers;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.LogarithmicExpansion;

namespace TaylorSeries
{
    static class Program
    {

        static void Main()
        {
            
            LogarithmicExpansion exp = new LogarithmicExpansion(3, 0.0001);
            Console.WriteLine("ATS:"+ exp.Calculate().Answer);
            Console.Read();
        }
    }
}
