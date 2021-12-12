using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class TokensExpVal: ExpressionValidation
    {
        public TokensExpVal(ConfigParams configParams, string[] tokens) : base(configParams, tokens) { }

        public override bool Validate()
        {
            int i = 0;
            int length = 1;
            while (i < _expression.Length)
            {
                string token = _expression.Substring(i, length);
                while (!(_allOperators.Contains(token) || token == _configParams.parentheses[0] 
                    || token == _configParams.parentheses[1] || double.TryParse(token, out double val)))
                {
                    length++;
                    if (length > _expression.Length - i)
                    {
                        Console.WriteLine("ERROR! Invalid operator");
                        return false;
                    }
                    token = _expression.Substring(i, length);
                }
                i += length;
                length = 1;
            }
            return true;
        }
    }
}
