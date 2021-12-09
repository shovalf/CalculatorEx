using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public interface IOperator
    {
        double Activate(string oper, List<double> operands);
    }
}
