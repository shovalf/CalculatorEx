using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class Validation
    {
        protected ConfigParams _configParams;
        protected List<string> _allOperators;
        protected List<string> _binaryOperators;
        protected List<string> _unaryOperators;
        protected string[] _tokens;

        public Validation(ConfigParams configParams, string[] tokens)
        {
            _configParams = configParams;
            _binaryOperators = new List<string>(_configParams.binaryOperators.Keys);
            _unaryOperators = new List<string>(_configParams.unaryOperators.Keys);
            _allOperators = _binaryOperators.Union(_unaryOperators).ToList();
            _tokens = tokens;
        }

        private bool IsStartEndOperator()
        {
            bool check = !(_allOperators.Contains(_tokens[0]) || _allOperators.Contains(_tokens[_tokens.Length - 1]));
            if (!check)
            {
                Console.WriteLine("ERROR! Expression starts or ends with an operator");
            }
            return check;
        }

        private bool IsBalancedExpression()
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

        public bool Validate()
        {
            return IsStartEndOperator() && IsBalancedExpression() ;
        }
    }
}
