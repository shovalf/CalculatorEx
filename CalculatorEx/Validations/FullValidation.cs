using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class FullValidation
    {
        private StartEndExpVal _startEndExpVal;
        private ParenthesesValidation _parenthesesValidation;
        private BinaryOperatorValidation _binaryOperatorValidation;
        private UnaryOperatorValidation _unaryOperatorValidation;
        private TokensExpVal _tokensExpVal;

        private List<string> _allOperators;
        private List<string> _binaryOperators;
        private List<string> _unaryOperators;
        private List<string> _parentheses;

        private string _expression;

        public FullValidation(ConfigParams configParams, string[] tokens)
        {
            _startEndExpVal = new StartEndExpVal(configParams, tokens);
            _parenthesesValidation = new ParenthesesValidation(configParams, tokens);
            _tokensExpVal = new TokensExpVal(configParams, tokens);

            _binaryOperatorValidation = new BinaryOperatorValidation(configParams, tokens);
            _unaryOperatorValidation = new UnaryOperatorValidation(configParams, tokens);

            _binaryOperators = new List<string>(configParams.binaryOperators.Keys);
            _unaryOperators = new List<string>(configParams.unaryOperators.Keys);
            _allOperators = _binaryOperators.Union(_unaryOperators).ToList();
            _parentheses = configParams.parentheses;

            _expression = String.Join("", tokens);
        }

        public bool FullOperatorValidation()
        {
            foreach (string oper in _allOperators)
            {
                int i = 0;
                while (i + oper.Length < _expression.Length)
                {
                    if (_expression.Substring(i, oper.Length) == oper)
                    {
                        if (_binaryOperators.Contains(oper))
                        {
                            if (!_binaryOperatorValidation.Validate(oper, i, i + oper.Length - 1))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!_unaryOperatorValidation.Validate(oper, i, i + oper.Length - 1))
                            {
                                return false;
                            }
                        }
                    }
                    i++;
                }
            }
            return true;
        }

        public bool Validate()
        {
            return _startEndExpVal.Validate() && _parenthesesValidation.Validate() 
                && _tokensExpVal.Validate() && FullOperatorValidation();
        }
    }
}
