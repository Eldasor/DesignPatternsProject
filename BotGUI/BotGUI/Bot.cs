using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // ...it took a while for me to remember C# has get/set keywords...
    internal class Bot : IListener
    {
        protected String name;
        protected float cash;
        List<IStrategy> strategies;
        Dictionary<String, ShareDuple> shares;

        public Bot(String n, float val)
        {
            name = n;
            cash = val;
            strategies = new List<IStrategy>();
            shares = new Dictionary<String, ShareDuple>();
            Market.getInstance().addListener(this);
        }

        public float getCash()
        {
            return cash;
        }
        public int getShare(String s)
        {
            return shares.GetValueOrDefault(s, new ShareDuple(0, 0)).num;
        }
        public float getCost(String s)
        {
            return shares.GetValueOrDefault(s, new ShareDuple(0, 0)).cost;
        }

        public String getName()
        {
            return name;
        }
        public void addStrategy(IStrategy s)
        {
            strategies.Add(s);
        }

        public void removeStrategy(int i)
        {
            if (i <= strategies.Count)
                strategies.RemoveAt(i);
        }
        public void notify()
        {
            List<IStrategy> temp = new List<IStrategy>();
            foreach (var strategy in strategies)
            {
                AbstractTrade? trade = strategy.decide();
                if (validate(trade))
                {
                    submit(trade);
                    if (trade.getKill())
                        temp.Add(strategy);
                }
            }
            foreach (var trade in temp)
                strategies.Remove(trade);
        }

        public void submit(AbstractTrade trade)
        {
            if (trade.holdAssets())
                Market.getInstance().submit(trade);
        }

        private bool validate(AbstractTrade? trade)
        {
            // no trade was decided!
            if (trade == null)
                return false;
            return trade.validate();
        }

        public void cashTransact(float val, bool force = false)
        {
            if (!force && cash + val < 0)
                throw new ImproperValueException();
            cash += val;
        }

        public float calcVal()
        {
            float ret = cash;
            Market m = Market.getInstance();
            foreach (String s in shares.Keys)
                ret += shares[s].num * m.getVal(s, m.getPrevDate(m.getDate()));
            return ret;
        }

        public void shareTransact(String ticker, int shift, float curPrice, bool force = false)
        {
            ShareDuple temp = shares.GetValueOrDefault(ticker, new ShareDuple(0, 0));
            if (!force && temp.num + shift < 0)
                throw new ImproperValueException();
            temp.num += shift;
            temp.cost += shift * curPrice;
            shares[ticker] = temp;
        }

        public String describe()
        {
            String ret = name + "\n";
            ret += "Cash on hand: " + cash.ToString() + "\n";
            ret += "Shares:\n";
            foreach (String s in shares.Keys)
                ret += s + ": " + shares[s].num + "\n";
            foreach (IStrategy s in strategies)
            {
                ret += "------------\n";
                ret += s.describe();
            }
            return ret;
        }
    }
}
