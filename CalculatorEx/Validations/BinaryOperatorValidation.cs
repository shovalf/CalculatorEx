using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class BinaryOperatorValidation: OperatorValidation
    {
        public BinaryOperatorValidation(ConfigParams configParams, string[] tokens) : 
            base(configParams, tokens) { }

        public bool IsParenthesesInvalid(int startIndex, int endIndex)
        {
            if (_tokens[startIndex - 1] == _configParams.parentheses[0] 
                || _tokens[endIndex + 1] == _configParams.parentheses[1])
            {
                Console.WriteLine($"ERROR! {_configParams.parentheses[0]} before " +
                    $"{_expression.Substring(startIndex, endIndex - startIndex)} or " +
                    $"{_configParams.parentheses[1]} after operator");
                return false;
            }
            return true;
        }

        public bool IsConsecutiveOperators(string operExpression, int startIndex)
        {
            foreach (string oper in _binaryOperators)
            {
                if (_expression.Substring(startIndex - operExpression.Length, operExpression.Length) == oper ||
                    _expression.Substring(startIndex + 1, operExpression.Length) == oper)
                {
                    Console.WriteLine("ERROR! Two binary operators in succession");
                    return false;
                }
            }
            return true;
        }

        public override bool Validate(string oper, int startIndex, int endIndex)
        {
            return IsParenthesesInvalid(startIndex, endIndex) && IsConsecutiveOperators(oper, startIndex);
        }
    }
}
