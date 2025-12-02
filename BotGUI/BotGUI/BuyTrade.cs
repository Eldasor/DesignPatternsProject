using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class BuyTrade : AbstractTrade
    {
        int boughtNum;
        float boughtPrice;
        public BuyTrade(Func<float, float, float, int, int> foo, Bot b) : base(foo, b) { }
        public override void execute()
        {
            Market m = Market.getInstance();
            boughtPrice = m.getVal(getTicker(), m.getDate());
            boughtNum = getTradeType().Invoke(boughtPrice, getMinimum(), getMaximum(), getShares());
            getReceiver().cashTransact(getMaximum() - boughtNum * boughtPrice);
            getReceiver().shareTransact(getTicker(), boughtNum, boughtPrice);
            if (boughtNum > 0)
            {
                m.addLog("Buy for " + boughtNum + " " + getTicker() + " for " + getReceiver().getName() + " executed at " + boughtPrice + "\n");
                m.addBListener(this);
            }
        }

        public override bool validate()
        {
            return getReceiver().getCash() >= getMinimum()
                && getMinimum() <= getMaximum();
        }

        public override bool holdAssets()
        {
            try
            {
                getReceiver().cashTransact(-1 * getMaximum());
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public override void cancel()
        {
            getReceiver().cashTransact(getMaximum(), true);
        }

        public override bool back()
        {
            if (getDate() < Market.getInstance().getDate())
                return false;
            getReceiver().cashTransact(boughtNum * boughtPrice, true);
            getReceiver().shareTransact(getTicker(), -1 * boughtNum, boughtPrice, true);
            return true;
        }

        public override String describe()
        {
            String ret = "Buy order\n";
            ret += "From " + getReceiver().getName() + "\n";
            ret += getShares().ToString() + " shares of " + getTicker() + "\n";
            ret += "Min value: " + getMinimum().ToString() + ", Max value: " + getMaximum().ToString() + "\n";
            return ret;
        }
    }
}
