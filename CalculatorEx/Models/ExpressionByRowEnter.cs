using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class ExpressionByRowEnter : IExpression
    {
        public string[] Process(string expression)
        {
            List<string> tockens = new List<string>() { };
            string str = expression;
            while (str != "")
            {
                tockens.Add(str);
                str = Console.ReadLine();
            }
            return tockens.ToArray();
        }
    }
}
