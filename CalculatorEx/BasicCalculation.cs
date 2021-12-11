using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class BasicCalculation : FullCalculation
    {
        public BasicCalculation(string[] tokens) : base(tokens) { }

        public override void ShowResult(double result)
        {
            Console.WriteLine(result);
        }
    }
}
