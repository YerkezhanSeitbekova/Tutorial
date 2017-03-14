using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc
{
    public class CalcBrain
    {
        public double first = 0.0;
        public double second = 0.0;
        public string op = "";
        public double result = 0.0;
        public void calculate()
        {
            if (op == "+")
            {
                result = first + second;
            }
        }
    }
}
