using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEx
{
    public abstract class Validation
    {
        protected ConfigParams _configParams;

        public Validation(ConfigParams configParams)
        {
            _configParams = configParams;
        }

        public abstract bool Validate(string[] tokens);
    }
}
