using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class BinaryOperator : IOperator
    {
        public double Activate(string oper, List<double> operands)
        {
            switch (oper)
            {
                case "+":
                    return operands[0] + operands[1];
                case "-":
                    return operands[1] - operands[0];
                case "*":
                    return operands[0] * operands[1];
                case "/":
                    return operands[1] / operands[0];
                default:
                    return default;
            }
        }
    }
}
