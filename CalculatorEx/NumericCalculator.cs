using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class NumericCalculator
    {
        private ConfigParams _configParams;

        private string[] _tokens;
        private Priority _priority;

        private Stack<double> _values = new Stack<double>();
        private Stack<string> _ops = new Stack<string>();

        private BinaryOperator _binaryOperatorActivation = new BinaryOperator();
        private UnaryOperator _unaryOperatorActivation = new UnaryOperator();

        public NumericCalculator(string[] tokens, Priority priority, ConfigParams configParams)
        {
            _configParams = configParams;
            _tokens = tokens;
            _priority = priority;
        }

        private void CalculateBasicExpression()
        {
            if (_configParams.unaryOperators.ContainsKey(_ops.Peek()))
            {
                _values.Push(_unaryOperatorActivation.Activate(_ops.Pop(), 
                    new List<double>() { _values.Pop() }));
            }
            else
            {
                _values.Push(_binaryOperatorActivation.Activate(_ops.Pop(), 
                    new List<double>() { _values.Pop(), _values.Pop() }));
            }
        }

        private void HandleClosingParenthes()
        {
            while (_ops.Peek() != _configParams.parentheses[0])
            {
                CalculateBasicExpression();
            }
            _ops.Pop();
        }

        private void HandleOperators(string oper)
        {
            while (_ops.Count > 0 && _priority.DeterminePriority(oper, _ops.Peek()))
            {
                CalculateBasicExpression();
            }
            _ops.Push(oper);
        }

        public int HandleNumbers(int i)
        {
            StringBuilder sbuf = new StringBuilder();
            while (i < _tokens.Length && double.TryParse(_tokens[i], out double value))
            {
                sbuf.Append(_tokens[i++]);
            }
            _values.Push(double.Parse(sbuf.ToString()));
            i--;
            return i;
        }

        public int HandleOperatorMultipyChars(int i)
        {
            StringBuilder sbuf = new StringBuilder();
            while (!double.TryParse(_tokens[i], out double number))
            {
                if (_configParams.binaryOperators.ContainsKey(sbuf.ToString()) || _configParams.unaryOperators.ContainsKey(sbuf.ToString()))
                {
                    break;
                }
                sbuf.Append(_tokens[i++]);
            }
            i--;
            HandleOperators(sbuf.ToString());
            return i;
        }

        public double Calculate()
        {
            for (int i = 0; i < _tokens.Length; i++)
            {
                if (_configParams.skipTokens.Contains(_tokens[i]))
                {
                    continue;
                }
                if (double.TryParse(_tokens[i], out double num))
                {
                    i = HandleNumbers(i);
                }
                else if (_tokens[i] == _configParams.parentheses[0])
                {
                    _ops.Push(_tokens[i]);
                }
                else if (_tokens[i] == _configParams.parentheses[1])
                {
                    HandleClosingParenthes();
                }
                else if (_configParams.binaryOperators.ContainsKey(_tokens[i]) || _configParams.unaryOperators.ContainsKey(_tokens[i]))
                {
                    HandleOperators(_tokens[i]);
                }
                else if (_configParams.unaryOperators.ContainsKey(_ops.Peek()))
                {
                    _values.Push(_unaryOperatorActivation.Activate(_ops.Pop(), new List<double>() { _values.Pop() }));
                }
                else
                {
                    i = HandleOperatorMultipyChars(i);
                }
            }
            while (_ops.Count > 0)
            {
                CalculateBasicExpression();
            }
            return _values.Pop();
        }
    }
}
