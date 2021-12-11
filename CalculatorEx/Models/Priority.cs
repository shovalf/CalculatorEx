using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class Priority
    {
        private ConfigParams _configParams;

        public Priority(ConfigParams configParams)
        {
            _configParams = configParams;
        }

        public bool DeterminePriority(string oper, string operTopStack)
        {
            if (_configParams.parentheses.Contains(operTopStack))
            {
                return false;
            }
            if (_configParams.unaryOperators.ContainsKey(oper) && _configParams.binaryOperators.ContainsKey(operTopStack))
            {
                return false;
            }
            if (_configParams.unaryOperators.ContainsKey(operTopStack))
            {
                return true;
            }
            if (_configParams.binaryOperators[operTopStack] < _configParams.binaryOperators[oper])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
