using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.HiperbolicalExpansions
{
    class HiperbolicalCothExpansion : ITaylorExpansion
    {

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
        public HiperbolicalCothExpansion(double error, double number)
        {
            this.Error = error;
            this.Number = number;
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

                HiperbolicalSineExpansion sinh = new HiperbolicalSineExpansion(Error, Number);
                HiperbolicalCoshExpansion cosh = new HiperbolicalCoshExpansion(Error, Number);

                result.Answer = cosh.Calculate().Answer / sinh.Calculate().Answer;

                return result;
            }
        }
    }
}
