using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class ExpressionRow: IExpression
    {
        public string[] Process(string expression)
        {
            string[] processedExpression = new string[expression.Length];
            for (int i=0;i<expression.Length;i++)
            {
                processedExpression[i] = expression[i].ToString();
            }
            return processedExpression ;
        }
    }
}
