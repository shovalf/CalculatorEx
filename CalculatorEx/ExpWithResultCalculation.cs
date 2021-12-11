using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    class ExpWithResultCalculation: FullCalculation
    {
        public ExpWithResultCalculation(string[] tokens) : base(tokens) { }

        public override void ShowResult(double result)
        {
            Console.WriteLine($"{string.Join("", _tokens)} = {result}");
        }
    }
}
