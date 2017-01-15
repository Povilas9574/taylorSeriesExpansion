using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;
using TaylorSeries.MathSAF.MathSAF.ErrorEvaluationAPI;

namespace TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions
{
    class Power : ITaylorExpansion
    {
        private double _error;
        private double _x;
        private double _a;
        private IErrorEvaluator evaluator;// = new Evaluator();
        private double _mult = 1;
        private double _xKappa;// -1 < x < 1

        public Power(double error, double x, double a, IErrorEvaluator Evaluator)
        {
            _error = error;
            _x = x;
            _a = a;
            evaluator = Evaluator;
        }
        public Result Calculate()
        {
            double result = 0;
            int xInt = Convert.ToInt32(_x);
            int aInt = Convert.ToInt32(_a);
            if (_x == xInt && _a == aInt && _a > 0)//2^2 -2^2                                   +
            {
                result = Math.Pow(_x, _a);
            }
            else
            {
                if(_x == xInt && _a == aInt && _x > 0 && _a < 0)//2^-2                          +
                {
                    xFix(true, _a%2 == 0);
                    int n = evaluator.Evaluate(getM(), _error, _xKappa);
                    result = getTaylorResult(n);
                }else if(_x == xInt && _a == aInt && _x < 0 && _a < 0)//-2^-2                   +
                {
                    xFix(true, _a % 2 == 0);
                    int n = evaluator.Evaluate(getM(), _error, _xKappa);
                    result = getTaylorResult(n);
                }
                else if(_x == xInt && _a != aInt && _x > 0 && _a > 0)//2^1/2                    +
                {
                    if (_x == 2)
                    {
                        xFix(false, _a % 2 == 0);
                        int n = evaluator.Evaluate(getM(), _error, _xKappa);
                        result = getTaylorResult(n);
                    }
                    else
                    {
                        xFix(false, _a % 2 == 0);
                        int n = evaluator.Evaluate(getM(), _error, _xKappa);
                        result = getTaylorResult(n);
                    }
                }else if(_x == xInt && _a != aInt && _x > 0 && _a < 0)//2^-(1/2)                +
                {
                    xFix(true, _a % 2 == 0);
                    int n = evaluator.Evaluate(getM(), _error, _xKappa);
                    result = getTaylorResult(n);
                }
                else if(_x == xInt && _a != aInt && _x < 0 && _a > 0)//-2^1/2                   +negalima
                {
                    //Result.NotExist = true;
                }
                else if(_x == xInt && _a != aInt && _x < 0 && _a < 0)//-2^-(1/2)                +negalima
                {
                    //Result.NotExist = true;
                }
                else if(_x != xInt && _a == aInt && _x > 0 && _a > 0)//(1/2)^2                  +
                {
                    xFix(false, _a % 2 == 0);
                    int n = evaluator.Evaluate(getM(), _error, _xKappa);
                    result = getTaylorResult(n);
                }
                else if(_x != xInt && _a == aInt && _x > 0 && _a < 0)//(1/2)^-2                 +    
                {
                    if((1/_x) == Convert.ToInt32(1/_x))
                    {
                        result = Math.Pow(1 / _x, Math.Abs(_a));
                    }
                    else
                    {
                        xFix(true, _a % 2 == 0);
                        int n = evaluator.Evaluate(getM(), _error, _xKappa);
                        result = getTaylorResult(n);
                    }
                }else if(_x != xInt && _a == aInt && _x < 0 && _a > 0)//-(1/2)^2                +
                {
                    xFix(false, _a % 2 == 0);
                    int n = evaluator.Evaluate(getM(), _error, _xKappa);
                    result = getTaylorResult(n);
                }
                else if(_x != xInt && _a == aInt && _x < 0 && _a < 0)//-(1/2)^-2                +
                {
                    if ((1 / _x) % (1 / _x) == 0)
                    {
                        result = Math.Pow(1 / _x, Math.Abs(_a));
                    }
                    else
                    {
                        xFix(true, _a % 2 == 0);
                        int n = evaluator.Evaluate(getM(), _error, _xKappa);
                        result = getTaylorResult(n);
                    }
                }
                else if(_x != xInt && _a != aInt && _x > 0 && _a > 0)//(1/2)^(1/2)              +
                {
                    xFix(false, _a % 2 == 0);
                    int n = evaluator.Evaluate(getM(), _error, _xKappa);
                    result = getTaylorResult(n);
                }
                else if(_x != xInt && _a != aInt && _x > 0 && _a < 0)//(1/2)^-(1/2)             +
                {
                    if ((1 / _x) == Convert.ToInt32(1/_x))
                    {
                        if (1 / _x == 2)
                        {
                            xFix(true, _a % 2 == 0);
                            int n = evaluator.Evaluate(getM(), _error, _xKappa);
                            result = getTaylorResult(n);
                        }
                        else
                        {
                            xFix(true, _a % 2 == 0);
                            int n = evaluator.Evaluate(getM(), _error, _xKappa);
                            result = getTaylorResult(100);
                        }
                    }
                    else
                    {
                        xFix(true, _a % 2 == 0);
                        int n = evaluator.Evaluate(getM(), _error, _xKappa);
                        result = getTaylorResult(100);
                    }
                }
                else if(_x != xInt && _a != aInt && _x < 0 && _a > 0)//-(1/2)^(1/2)             +negalima
                {
                    //Result.NotExist = true;
                }
                else                                                      //-(1/2)^-(1/2)       +negalima
                {
                    //Result.NotExist = true;
                }
            }
            result = result * _mult;
            return new Result();
        }
        private double getM()
        {
            double result;
            double xM, aM;
            xM = _x;
            aM = _a;
            if (xM % xM != 0)
            {
                xM = Math.Truncate(xM) + 1;
            }
            if (aM % aM != 0)
            {
                aM = Math.Truncate(aM) + 1;
            }
            result = Math.Pow(xM, aM);
            return result;
        }
        private double getTaylorResult(double n)
        {
            double result;
            double temp = 1;
            if (n == 1)
            {
                result = 1 + _xKappa * _a;
            }
            else
            {
                result = 1 + _xKappa * _a;
                for (int i = 2; i <= n+1; i++)
                {
                    temp = 1;
                    for(int j = 1; j < i; j++)
                    {
                        temp *= _a - j;
                    }

                    result += (_a * Math.Pow(_xKappa, i) * temp) / (factorial(i));
                }
            }
            return result;
        }
        private double factorial(int n)
        {
            double result = 1;
            for(int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        private void xFix(bool negativePow, bool evenPow)
        {
            double temp;
            if (evenPow)
            {
                temp = Math.Abs(_x);
            }
            else
            {
                temp = _x;
            }
            if (negativePow)
            {
                temp = 1 / _x;
                _a = Math.Abs(_a);
            }
            if(Math.Abs(temp) < 2)
            {
                if (temp < 0)
                {
                    temp -= 1;
                    _xKappa = 1 / temp;
                    _mult = Math.Pow(temp, _a);
                }
                else
                {
                    _xKappa = temp - 1;
                    _mult = 1;
                }
            }
            else if(temp == 2)
            {
                _xKappa = 0;
                _mult = Math.Pow(2, _a);
            }
            else
            {
                temp -= 1;
                _xKappa = 1 / temp;
                _mult = Math.Pow(temp, _a);
            }
        }
        private double doubleFactorial(int n)
        {
            double result = 1;
            while(n > 0)
            {
                result *= n;
                n -= 2;
            }

            return result;
        }
    }
}
