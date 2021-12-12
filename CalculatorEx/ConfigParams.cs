using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class ConfigParams
    {
        public readonly List<string> skipTokens = new List<string>() { " " };
        public readonly Dictionary<string, int> binaryOperators = new Dictionary<string, int>()
            {
                {"+", 0 }, {"-", 0}, {"*", 1}, {"/", 1}
            };
        public readonly Dictionary<string, int> unaryOperators = new Dictionary<string, int>()
            {
                {"sin", 1 }, {"cos", 1}
            };
        public readonly List<string> parentheses = new List<string>() { "(", ")" };
    }
}
