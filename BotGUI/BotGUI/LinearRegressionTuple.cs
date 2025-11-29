using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // basic tuple
    internal struct LinearRegressionTuple
    {
        public float slope;
        public float rsq;
        public LinearRegressionTuple(float a, float b)
        {
            slope = a;
            rsq = b;
        }
    }
}
