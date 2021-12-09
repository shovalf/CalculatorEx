using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public class NumberValidation : Validation
    {
        public NumberValidation(ConfigParams configParams) : base(configParams) { }

        public override bool Validate(string[] tokens)
        {
            foreach(string tocken in tokens)
            {
                return true;
            }
            return true;
        }
    }
}
