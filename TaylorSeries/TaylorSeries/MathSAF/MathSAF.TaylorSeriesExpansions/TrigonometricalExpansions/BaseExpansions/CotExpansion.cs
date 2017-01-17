using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.BaseExpansions
{
    class CotExpansion : ITaylorExpansion
    {
        public CotExpansion(double x, double error)
        {
            this.Number = x;
            this.Error = error;
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
            Result result = new Result();
            if (Number == 0)
            {
                result.Answer = 0;
                return result;
            }
            else
            {
                SinExpansion sin = new SinExpansion(Number, Error);
                CosExpansion cos = new CosExpansion(Number, Error);

                result.Answer = cos.Calculate().Answer / sin.Calculate().Answer;

                return result;
            }
        }
    }
}
