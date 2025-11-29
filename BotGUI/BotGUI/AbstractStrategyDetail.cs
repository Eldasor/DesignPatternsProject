using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // this should function like a decorator for strategies
    // the downside to how this is interleved with a few design patterns
    // is the order of decorators is VERY important. do not stack them
    // arbitrarily
    internal abstract class AbstractStrategyDetail : IStrategy
    {
        public IStrategy core;
        public AbstractStrategyDetail(IStrategy s)
        {
            core = s;
        }
        // the paramater is for assigning a ticker
        // ...it's really not good form to do it this way, since most
        // of the time it's passing nothing, but at some point in the
        // decorator's path it needs to branch based on multiple tickers
        public abstract AbstractTrade? decide(String s = "");
        public abstract String describe();
    }
}
