using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public abstract class FullCalculation
    {
        protected ConfigParams _configParams;
        protected string[] _tokens;
        protected Priority _priority;
        protected NumericCalculator _calculator;
        protected FullValidation _validation;

        public FullCalculation(string[] tokens)
        {
            _tokens = tokens;
            _configParams = new ConfigParams();
            _priority = new Priority(_configParams);
            _validation = new FullValidation(_configParams, tokens);
            _calculator = new NumericCalculator(_tokens, _priority, _configParams);
        }

        public void Calculate()
        {
            if (_validation.Validate())
            {
                double result = _calculator.Calculate();
                ShowResult(result);
            }
        }

        public abstract void ShowResult(double result);
    }
}
