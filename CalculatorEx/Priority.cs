using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class Priority
    {
        public Dictionary<string, int> BinaryOperators { get; }
        public Dictionary<string, int> UnaryOperators { get; }
        public List<string> Parentheses { get; }

        public Priority(Dictionary<string, int> binaryOperators, Dictionary<string, int> unaryOperators, List<string> parentheses)
        {
            BinaryOperators = binaryOperators;
            UnaryOperators = unaryOperators;
            Parentheses = parentheses;
        }

        public bool DeterminePriority(string oper, string operTopStack)
        {
            if (Parentheses.Contains(operTopStack))
            {
                return false;
            }
            if (UnaryOperators.ContainsKey(oper) && BinaryOperators.ContainsKey(operTopStack))
            {
                return false;
            }
            if (UnaryOperators.ContainsKey(operTopStack))
            {
                return true;
            }
            if (BinaryOperators[operTopStack] < BinaryOperators[oper])
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
