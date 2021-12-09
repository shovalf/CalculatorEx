using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class ExpressionByRowEnter : IExpression
    {
        public string[] Process()
        {
            List<string> tockens = new List<string>();
            string str = "";
            do
            {
                str = Console.ReadLine();
                tockens.Add(str);
            } while (str != "");
            return tockens.ToArray();
        }
    }
}
