using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class ParenthesesValidation : ExpressionValidation
    {
        public ParenthesesValidation(ConfigParams configParams, string[] tokens) : base(configParams, tokens) { }

        public override bool Validate()
        {
            int count = 0;
            foreach (string token in _tokens)
            {
                if (token == _configParams.parentheses[0])
                {
                    count++;
                }
                else if (token == _configParams.parentheses[1])
                {
                    count--;
                    if (count < 0)
                    {
                        break;
                    }
                }
            }
            if (count == 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("ERROR! Expression is unbalanced");
                return false;
            }
        }
    }
}
