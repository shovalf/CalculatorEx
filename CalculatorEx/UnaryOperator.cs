using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class UnaryOperator: IOperator
    {
        public double Activate(string oper, List<double> operands)
        {
            switch (oper)
            {
                case "s":
                    return Math.Sin(operands[0]);
                case "c":
                    return Math.Cos(operands[0]);
                default:
                    return default;
            }
        }
    }
}
