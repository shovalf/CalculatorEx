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
                Priority priority = new Priority(configParams);
                ExpressionRow expression = new ExpressionRow();
                string[] tokens = expression.Process();
                Validation validation = new Validation(configParams, tokens);
                if (validation.Validate())
                {
                    NumericCalculator calc = new NumericCalculator(tokens, priority, configParams);
                    Console.WriteLine(calc.Calculate());
                }
                else
                {
                    Console.WriteLine("EROOR!");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR! {e.Message}");
            }
        }
    }
}
