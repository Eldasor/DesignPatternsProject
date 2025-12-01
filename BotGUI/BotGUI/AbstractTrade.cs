using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // this should function like a command
    internal abstract class AbstractTrade : IBackListener
    {
        Bot receiver;
        Date date;
        float minimum;
        float maximum;
        String ticker;
        Func<float, float, float, int, int> trade;
        bool kill;
        int shares;
        public AbstractTrade(Func<float, float, float, int, int> foo, Bot b)
        {
            receiver = b;
            trade = foo;
            date = Market.getInstance().getDate();
            ticker = "";
        }
        public Bot getReceiver()
        {
            return receiver;
        }
        public Func<float, float, float, int, int> getTradeType()
        {
            return trade;
        }
        public void setMinimum(float m)
        {
            minimum = m;
        }
        public float getMinimum()
        {
            return minimum;
        }
        public void setMaximum(float m)
        {
            maximum = m;
        }
        public float getMaximum()
        {
            return maximum;
        }

        public void setTicker(String s)
        {
            ticker = s;
        }
        public String getTicker()
        {
            return ticker;
        }
        public Date getDate()
        {
            return date;
        }

        public bool getKill()
        {
            return kill;
        }

        public void setKill(bool b)
        {
            kill = b;
        }
        public int getShares()
        {
            return shares;
        }
        public void setShares(int n)
        {
            shares = n;
        }

        public abstract bool holdAssets();

        public abstract void execute();
        public abstract bool validate();

        public abstract void cancel();

        public abstract String describe();

        public abstract bool back();
    }
}
