using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class NumericCalculator
    {
        private string[] _tokens;
        private Priority _priority;
        private List<string> _skipTokens;
        private Dictionary<string, int> _binaryOperators;
        private Dictionary<string, int> _unaryOperators;
        private List<string> _parentheses;

        private Stack<double> _values = new Stack<double>();
        private Stack<string> _ops = new Stack<string>();
        private BinaryOperator _binaryOperatorActivation = new BinaryOperator();
        private UnaryOperator _unaryOperatorActivation = new UnaryOperator();

        public NumericCalculator(string[] tokens, Priority priority, List<string> skipTokens)
        {
            _tokens = tokens;
            _priority = priority;
            _skipTokens = skipTokens;
            _binaryOperators = priority.BinaryOperators;
            _unaryOperators = priority.UnaryOperators;
            _parentheses = priority.Parentheses;
        }

        private void HandleClosingParenthes()
        {
            while (_ops.Peek() != _parentheses[0])
            {
                _values.Push(_binaryOperatorActivation.Activate(_ops.Pop(), new List<double>() { _values.Pop(), _values.Pop() }));
            }
            _ops.Pop();
        }

        private void HandleOperators(int i)
        {
            while (_ops.Count > 0 && _priority.DeterminePriority(_tokens[i], _ops.Peek()))
            {
                if (_unaryOperators.ContainsKey(_ops.Peek()))
                {
                    _values.Push(_unaryOperatorActivation.Activate(_ops.Pop(), new List<double>() { _values.Pop() }));
                }
                else
                {
                    _values.Push(_binaryOperatorActivation.Activate(_ops.Pop(), new List<double>() { _values.Pop(), _values.Pop() }));
                }
            }
            _ops.Push(_tokens[i]);
        }

        public void LastCalculation()
        {
            while (_ops.Count > 0)
            {
                if (_unaryOperators.ContainsKey(_ops.Peek()))
                {
                    _values.Push(_unaryOperatorActivation.Activate(_ops.Pop(), new List<double>() { _values.Pop() }));
                }
                else
                {
                    _values.Push(_binaryOperatorActivation.Activate(_ops.Pop(), new List<double>() { _values.Pop(), _values.Pop() }));
                }
            }
        }

        public double Calculate()
        {
            for (int i = 0; i < _tokens.Length; i++)
            {
                if (_skipTokens.Contains(_tokens[i]))
                {
                    continue;
                }
                if (double.TryParse(_tokens[i], out double num))
                {
                    StringBuilder sbuf = new StringBuilder();
                    while (i < _tokens.Length && double.TryParse(_tokens[i], out double value))
                    {
                        sbuf.Append(_tokens[i++]);
                    }
                    _values.Push(double.Parse(sbuf.ToString()));
                    i--;
                }
                else if (_tokens[i] == _parentheses[0])
                {
                    _ops.Push(_tokens[i]);
                }
                else if (_tokens[i] == _parentheses[1])
                {
                    HandleClosingParenthes();
                }
                else if (_binaryOperators.ContainsKey(_tokens[i]) || _unaryOperators.ContainsKey(_tokens[i]))
                {
                    HandleOperators(i);
                }
                else if (_unaryOperators.ContainsKey(_ops.Peek()))
                {
                    _values.Push(_unaryOperatorActivation.Activate(_ops.Pop(), new List<double>() { _values.Pop() }));

                }
            }
            LastCalculation();
            return _values.Pop();
        }
    }
}
