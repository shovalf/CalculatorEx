using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class UnaryOperatorValidation: OperatorValidation
    {
        public UnaryOperatorValidation(ConfigParams configParams, string[] tokens) : 
            base(configParams, tokens) { }

        public bool IsOpenParenthesis(string oper, int endIndex)
        {
            if (_tokens[endIndex + 1] != _configParams.parentheses[0])
            {
                Console.WriteLine($"ERROR! {oper} must have {_configParams.parentheses[0]} after it");
                return false;
            }
            return true;
        }

        public override bool Validate(string oper, int startIndex, int endIndex)
        {
            return IsOpenParenthesis(oper, endIndex);          
        }
    }
}
