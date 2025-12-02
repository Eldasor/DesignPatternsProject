using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class ChartPoint
    {
        int idx;
        float val = 0;

        public ChartPoint(int a, float b)
        {
            idx = a; val = b;
        }

        public int Idx
        {
            get { return idx; }
            set { idx = value; }
        }

        public float Val
        {
            get { return val; }
            set { val = value; }
        }
    }
}
