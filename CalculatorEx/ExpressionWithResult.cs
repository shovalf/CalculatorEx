using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class ExpressionWithResult
    {
        private ConfigParams _configParams;
        private string[] _tokens;
        private Priority _priority;
        private NumericCalculator _calculator;
        private FullValidation _validation;

        public ExpressionWithResult(string[] tokens)
        {
            _configParams = new ConfigParams();
            _priority = new Priority(_configParams);
            _tokens = tokens;
            _validation = new FullValidation(_configParams, tokens);
            _calculator = new NumericCalculator(_tokens, _priority, _configParams);
        }

        public void Calculate()
        {
            
            if (_validation.Validate())
            {
                double result = _calculator.Calculate();
                Console.WriteLine($"{string.Join("", _tokens)} = {result}");
            }
            else
            {
                //Environment.Exit(1);
            }
        }
    }
}
