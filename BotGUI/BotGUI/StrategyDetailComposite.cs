using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // this is NOT a composite design pattern, but resembles it
    // it's for a decorated strategy to handle multiple assigned tickers
    // if a composite is for a tree-like structure, and a decorator is
    // for a linear structure of added details, this is like having a
    // single point of many branches in the decorator's line
    // and then it makes a decision on how to converge them when passing
    // up the decorator's line

    // while with some difficulty you could make this a composite design
    // pattern, there's not any need in this use case. we don't want every
    // part of the decorator path to branch out like this. this should only
    // occur once in a decorator's design path
    internal class StrategyDetailComposite : AbstractStrategyDetail
    {
        private List<String> children;
        public StrategyDetailComposite(IStrategy s, List<String> tickers) : base(s)
        {
            children = tickers;
        }

        public override AbstractTrade? decide(String s = "")
        {
            List<AbstractTrade> trades = new List<AbstractTrade>();
            foreach(var t in children)
            {
                AbstractTrade? temp = core.decide(t);
                if (temp != null)
                {
                    trades.Add(temp);
                }
            }
            if (trades.Count == 0)
                return null;
            // doing it randomly, can't think of an easy way to filter this...
            return trades.ElementAt(Market.getInstance().random(trades.Count));
        }

        public override string describe()
        {
            return core.describe() + "On tickers: " + stringify(children) + "\n";
        }
        private String stringify(List<String> list)
        {
            String ret = "";
            for (int i = 0; i < list.Count; ++i)
                ret += list[i] + ((i < list.Count - 1) ? "," : "");
            return ret;
        }
    }
}
