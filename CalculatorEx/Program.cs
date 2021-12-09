using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> skipTokens = new List<string>() { " " };
            Dictionary<string, int> binaryOperators = new Dictionary<string, int>()
            {
                {"+", 0 }, {"-", 0}, {"*", 1}, {"/", 1}
            };
            Dictionary<string, int> unaryOperators = new Dictionary<string, int>()
            {
                {"s", 0 }, {"c", 0}
            };
            List<string> parentheses = new List<string>() { "(", ")" };

            try
            {
                Priority priority = new Priority(binaryOperators, unaryOperators, parentheses);
                ExpressionRow expression = new ExpressionRow();
                string[] tokens = expression.Process();
                NumericCalculator calc = new NumericCalculator(tokens, priority, skipTokens);
                Console.WriteLine(calc.Calculate());
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR! {e.Message}");
            }
        }
    }
}
