using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public abstract class ExpressionValidation
    {
        protected ConfigParams _configParams;
        protected List<string> _allOperators;
        protected List<string> _binaryOperators;
        protected List<string> _unaryOperators;
        protected string[] _tokens;
        protected string _expression;

        public ExpressionValidation(ConfigParams configParams, string[] tokens)
        {
            _configParams = configParams;
            _binaryOperators = new List<string>(_configParams.binaryOperators.Keys);
            _unaryOperators = new List<string>(_configParams.unaryOperators.Keys);
            _allOperators = _binaryOperators.Union(_unaryOperators).ToList();
            _tokens = tokens;
            _expression = String.Join("", _tokens);
        }

        public abstract bool Validate();
    }
}
