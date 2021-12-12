using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    class StartEndExpVal : ExpressionValidation
    {
        public StartEndExpVal(ConfigParams configParams, string[] tokens) : base(configParams, tokens) { }

        public bool StartExpression()
        {
            foreach (string oper in _allOperators)
            {
                if (_expression.StartsWith(oper) && _binaryOperators.Contains(oper))
                {
                    Console.WriteLine($"ERROR! Expression cannot start with {oper}");
                    return false;
                }
                else if (_expression.StartsWith(oper) && _unaryOperators.Contains(oper))
                {
                    return true;
                }
            }
            if (!(_tokens[0] == _configParams.parentheses[0] || double.TryParse(_tokens[0], out double val)))
            {
                Console.WriteLine($"ERROR! Expression must start with {_configParams.parentheses[0]} " +
                    $"or number or unary operator");
                return false;
            }
            return true;
        }

        public bool EndExpression()
        {
            foreach (string oper in _allOperators)
            {
                if (_expression.EndsWith(oper))
                {
                    Console.WriteLine($"ERROR! Expression cannot end with {oper}");
                    return false;
                }
            }
            if (!(_tokens[_expression.Length-1] == _configParams.parentheses[1] || double.TryParse(_tokens[_expression.Length - 1], out double val)))
            {
                Console.WriteLine($"ERROR! Expression must end with {_configParams.parentheses[1]} or number");
                return false;
            }
            return true;
        }

        public override bool Validate()
        {
            return StartExpression() && EndExpression();
        }
    }
}
