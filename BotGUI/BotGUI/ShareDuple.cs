using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // duple for bot to store its shares and cost basis
    internal struct ShareDuple
    {
        public int num;
        public float cost;
        public ShareDuple(int a, float b) { num = a; cost = b; }
    }
}
