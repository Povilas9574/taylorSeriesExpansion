using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.BaseExpansions
{
    class TanExpansion : ITaylorExpansion
    {

        public TanExpansion(double x, double error)
        {
            this.Error = error;
            this.Number = x;
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

                result.Answer = sin.Calculate().Answer / cos.Calculate().Answer;

                return result;
            }
        }
    }
}
