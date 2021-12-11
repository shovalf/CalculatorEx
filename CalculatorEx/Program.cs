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
            try
            {
                string expressionUser;
                do
                {
                    expressionUser = Console.ReadLine();
                    if (expressionUser != "")
                    {
                        ExpressionRow expression = new ExpressionRow();
                        string[] tokens = expression.Process(expressionUser);
                        ConfigParams configParams = new ConfigParams();
                        Priority priority = new Priority(configParams);
                        FullValidation validation = new FullValidation(configParams, tokens);
                        if (validation.Validate())
                        {
                            NumericCalculator calc = new NumericCalculator(tokens, priority, configParams);
                            Console.WriteLine(calc.Calculate());
                        }
                    }
                } while (expressionUser != "");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR! {e.Message}");
            }
        }
    }
}
