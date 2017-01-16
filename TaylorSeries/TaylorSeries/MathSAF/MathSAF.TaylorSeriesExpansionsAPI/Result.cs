using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI
{
    class Result
    {
        private bool _exist = true;
        public double Answer
        {
            set;
            get;
        }
        public bool Exist
        {
            set
            {
                _exist = value;
            }
            get
            {
                return _exist;
            }
        }
    }
}
