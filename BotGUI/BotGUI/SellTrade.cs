using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class SellTrade : AbstractTrade
    {
        int sellNum;
        float sellPrice;
        float oldPrice; // to keep cost basis accurate
        public SellTrade(Func<float, float, float, int, int> foo, Bot b) : base(foo, b) { }
        public override void execute()
        {
            Market m = Market.getInstance();
            sellPrice = m.getVal(getTicker(), m.getDate());
            sellNum = getTradeType().Invoke(sellPrice, getMinimum(), getMaximum(), getShares());
            getReceiver().cashTransact(sellNum * sellPrice);
            getReceiver().shareTransact(getTicker(), getShares() - sellNum, oldPrice);
            if (sellNum > 0)
            {
                m.addBListener(this);
                m.addLog("Sell for " + sellNum + " " + getTicker() + "for " + getReceiver().getName() + " executed at " + sellPrice + "\n");
            }
        }
        public override bool validate()
        {
            return getShares() > 0 && getReceiver().getShare(getTicker()) >= getShares();
        }

        public override bool holdAssets()
        {
            try
            {
                oldPrice = getReceiver().getCost(getTicker());
                getReceiver().shareTransact(getTicker(), -1 * getShares(), oldPrice);
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public override void cancel()
        {
            getReceiver().shareTransact(getTicker(), getShares(), oldPrice, true);
        }

        public override bool back()
        {
            if (getDate() < Market.getInstance().getDate())
                return false;
            getReceiver().cashTransact(-1 * sellNum * sellPrice, true);
            getReceiver().shareTransact(getTicker(), sellNum, oldPrice, true);
            return true;
        }
        public override String describe()
        {
            String ret = "Sell order\n";
            ret += "From " + getReceiver().getName();
            ret += getShares().ToString() + " shares of " + getTicker() + "\n";
            ret += "Min value: " + getMinimum().ToString() + ", Max value: " + getMaximum().ToString() + "\n";
            return ret;
        }
    }
}
