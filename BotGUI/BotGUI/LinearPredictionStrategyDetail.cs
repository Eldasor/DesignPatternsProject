using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BotGUI
{
    // decides to trade based on a linear regression analysis of the stock
    // based on the past n days of information
    // the bot can't know future data - this is a lazy attempt to try and
    // guess the future. basically you can define if a stock has a certain
    // profile of its last trading - it looks like it is increasing or decreasing
    // reliably, so you want to buy or sell or w/e
    // you can stack these on top of each other, to create a "window" of acceptable
    // linear regression appearance
    internal class LinearPredictionStrategyDetail : AbstractStrategyDetail
    {
        private int length; // length of history to use for regression
        private bool reverse; // get BELOW a set slope, not above
        private float slope; // slope of line we want to be above (or below)
        private float? rsq; // r squared value - making sure data fits
        private bool noMissValues; // in case stock market is missing data
        private bool nmt; // temp storage across functions
        public LinearPredictionStrategyDetail(IStrategy s, int l, bool b, float sl, float? r = null, bool nm = false) : base(s)
        {
            length = l;
            reverse = b;
            slope = sl;
            rsq = r;
            noMissValues = nm;
            nmt = false;
        }
        public override AbstractTrade? decide(String s = "")
        {
            nmt = false;
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            LinearRegressionTuple lrt = getLinearRegression(trade.getTicker());
            if (noMissValues && nmt)
                return null;
            if (rsq != null && lrt.rsq < rsq)
                return null;
            if (reverse && lrt.slope > slope)
                return null;
            else if (!reverse && lrt.slope < slope)
                return null;
            return trade;
        }

        private LinearRegressionTuple getLinearRegression(String s)
        {
            float ra, rb;
            List<float> vals = new List<float>();
            Date d = Market.getDate();
            float mean = 0;
            for (int i = 1; i <= length; ++i)
            {
                d = Market.getPrevDate(d);
                vals.Prepend(Market.getVal(s, d));
                mean += vals.ElementAt(0);
                if (vals.ElementAt(0) == 0)
                    nmt = true;
            }
            float num = 0, den = 0;
            for (int i = 0; i < length; ++i)
            {
                num += (vals.ElementAt(i) - mean) * (i + 1 - ((float) length) / 2f);
                den += (i + 1 - ((float) length) / 2f) * (i + 1 - ((float) length) / 2f);
            }
            ra = num / den;
            float yi = ((float) length) / 2f - ra * mean;
            num = 0; den = 0;
            for (int i = 0; i < length; ++i)
            {
                num = (vals.ElementAt(i) - (i + 1) * ra - yi) * (vals.ElementAt(i) - (i + 1) * ra - yi);
                den = (vals.ElementAt(i) - mean) * (vals.ElementAt(i) - mean);
            }
            rb = 1f - num / den;
            return new LinearRegressionTuple(ra, rb);
        }

        public override string describe()
        {
            String ret = core.describe();
            ret += "When ";
            ret += (reverse) ? "below " : "above ";
            ret += "linear regression by last " + length.ToString() + "close prices\n";
            if (noMissValues)
                ret += "(no missing values) ";
            if (rsq != null)
                ret += "(r-squared must be >= " + rsq.ToString() + ")";
            if (noMissValues || rsq != null) ret += "\n";
            return ret;
        }
    }
}
