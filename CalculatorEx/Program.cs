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
            ConfigParams configParams = new ConfigParams();
            try
            {
                Priority priority = new Priority(configParams.binaryOperators, configParams.unaryOperators, configParams.parentheses);
                ExpressionRow expression = new ExpressionRow();
                string[] tokens = expression.Process();
                NumericCalculator calc = new NumericCalculator(tokens, priority, configParams.skipTokens);
                Console.WriteLine(calc.Calculate());
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR! {e.Message}");
            }
        }
    }
}
