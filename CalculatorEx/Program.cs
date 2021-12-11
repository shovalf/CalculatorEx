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
                        ExpressionRow expressionRow = new ExpressionRow();
                        string[] tokens = expressionRow.Process(expressionUser);
                        BasicCalculation calculation = new BasicCalculation(tokens);
                        calculation.Calculate();
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
